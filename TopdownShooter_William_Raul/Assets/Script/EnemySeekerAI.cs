using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemySeekerAI : MonoBehaviour
{
    private Transform target; 
    [SerializeField] private float _speed;
    [SerializeField] private float _nextWaypointDistance = 1f;
    [SerializeField] private float _rotationSpeed;
    private Path _path;
    private int _currentWaypoint = 0;
    private bool _reachEndOfPath = false;
    private Seeker _seeker;
    private Rigidbody2D _rb;
    
    // Start is called before the first frame update
    void Start()
    {
        _seeker = GetComponent<Seeker>();
        _rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("PlayerTank").transform;

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    private void UpdatePath()
    {
        if(_seeker.IsDone())
        {
            _seeker.StartPath(_rb.position, target.position, OnPathComplete);
        }
    }

    private void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            _path = p;
            _currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_path ==null)
        {
            return;
        }

        if(_currentWaypoint >= _path.vectorPath.Count)
        {
            _reachEndOfPath = true;
            return;
        }
        else
        {
            _reachEndOfPath = false;
        }

        Vector2 direction = ((Vector2)_path.vectorPath[_currentWaypoint] - _rb.position).normalized;
        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed*Time.deltaTime);

        Vector2 force = direction * _speed * Time.deltaTime;

        _rb.AddForce(force);

        float distance = Vector2.Distance(_rb.position, _path.vectorPath[_currentWaypoint]);

        if(distance < _nextWaypointDistance)
        {
            _currentWaypoint++;
        }
    }
}
