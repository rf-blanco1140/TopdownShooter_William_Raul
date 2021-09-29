using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossHairScript : MonoBehaviour
{
    public void Start()
    {
        //Cursor.visible = false;
    }


    public void Update()
    {
        Vector2 mousePos = Input.mousePosition;

        //Set fake mouse Cursor
        transform.position = mousePos;
    }
}
