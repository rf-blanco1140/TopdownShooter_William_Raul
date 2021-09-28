using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpUi : MonoBehaviour
{
    [SerializeField] private List<GameObject> _hearts;

    private void Start()
    {
        SetHeartIcons();
    }

    private void SetHeartIcons()
    {
        for(int i=0; i<3; i++)
        {
            _hearts.Add( GameObject.Find("Heart_" + (i + 1) ) );
        }
    }

    public void RemoveHeart(int pCurrentHP)
    {
        Debug.Log("heart indez: " + pCurrentHP);
        _hearts[pCurrentHP].SetActive(false);
    }

    public void AddHeart(int pCurrentHP)
    {
        _hearts[pCurrentHP-1].SetActive(true);
    }

    public void RecoverAllHearts()
    {
        for(int i = 0; i < 3; i++)
        {
            AddHeart(i+1);
        }
    }
}
