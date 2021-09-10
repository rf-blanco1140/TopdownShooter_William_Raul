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
        yield return new WaitForSeconds(.2f);
        _sr.material = _matDeault;
    }

    public void PlayInvulnerabilityFlash()
    {
        StartCoroutine("InvulnerabilityFlashRoutine");
    }

    public void StopInvulnerabilityFlash()
    {
        StopCoroutine("InvulnerabilityFlashRoutine");
    }
    IEnumerator InvulnerabilityFlashRoutine()
    {
        while(true)
        {
            Color sColor = _sr.color;
            sColor.a = 0f;
            _sr.color = sColor;
            yield return new WaitForSeconds(.05f);
            sColor.a = 255f;
            _sr.color = sColor;
            yield return new WaitForSeconds(.05f);
        }
    }
}
