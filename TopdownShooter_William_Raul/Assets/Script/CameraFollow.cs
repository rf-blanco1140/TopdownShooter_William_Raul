using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    Vector3 originalPos;

    private PauseMenuScript _pauseMenu;

    private void Start()
    {
        _pauseMenu = FindObjectOfType<PauseMenuScript>();
        target = GameObject.Find("PlayerTank").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        originalPos = transform.position;
    }



    public IEnumerator Shaking(float duration, float magnitude)
    {
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            if (!_pauseMenu.menuOn)
            {

            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(originalPos.x - x, originalPos.y - y, originalPos.z);

            elapsed += Time.deltaTime;
            yield return null;
            }
            else
            yield return null;
        }
        transform.localPosition = originalPos;
    }
}
