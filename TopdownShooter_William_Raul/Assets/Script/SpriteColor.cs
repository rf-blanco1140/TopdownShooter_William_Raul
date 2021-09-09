using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteColor : MonoBehaviour
{
    private Material _matDeault;
    private Material _matFlashWhite;
    private SpriteRenderer _sr;

    private void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _matDeault = _sr.material;
        _matFlashWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
    }

    public void ReturnToBaseColor()
    {

    }

    public void PlaySpriteDamageFlash()
    {
        StartCoroutine(DamageFlashRoutine());
    }

    IEnumerator DamageFlashRoutine()
    {
        _sr.material = _matFlashWhite;
        yield return new WaitForSeconds(.3f);
        _sr.material = _matDeault;
    }
}
