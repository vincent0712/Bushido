using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{

    bool isHitted = false;
    public float timeToColor;
    SpriteRenderer sr;
    Color defaultColor;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        defaultColor = sr.color;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isHitted)
        {
            isHitted = true;
            StartCoroutine("SwitchColor");
        }
    }

    IEnumerator SwitchColor()
    {
        sr.color = new Color(1f, 0.30196078f, 0.30196078f);
        yield return new WaitForSeconds(timeToColor);
        sr.color = defaultColor;
        isHitted = false;
    }
}
