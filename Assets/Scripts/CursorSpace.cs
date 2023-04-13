using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSpace : MonoBehaviour
{
    private Vector2 fingerpos;
    public GameObject mask;
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            fingerpos = Camera.main.ScreenToWorldPoint(touch.position);
            mask.transform.position = fingerpos;
        }
    }
}
