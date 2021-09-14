using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemySeekerAI : MonoBehaviour
{
    private Transform target; 
    [SerializeField] private float speed;
    [SerializeField] private float nextWaypointDistance = 3f;
    [SerializeField] private float rotationSpeed;
    private Path path;
    private int currentWaypoint = 0;
    private bool reachEndOfPath = false;
    private Seeker seeker;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("PlayerTank").transform;

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    private void UpdatePath()
    {
        if(seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    private void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(path ==null)
        {
            return;
        }

        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachEndOfPath = true;
            return;
        }
        else
        {
            reachEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed*Time.deltaTime);

        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }
}
