using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public Positiom nedeedPos;
    [SerializeField] private bool inRightPos;
    private Vector2 fingerpos;
    public bool dragging;
    private BoxCollider2D collider;
    private void Start()
    {
         collider = GetComponent<BoxCollider2D>();
    }
    private void OnMouseDown()
    {
        collider.enabled = false; 
        dragging = true;
    }
    private void OnMouseUp()
    {
        collider.enabled = true;
        dragging = false;
        RaycastHit2D raycast = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 1.25f), Vector2.down,1f);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y-1.25f), Vector2.down,Color.red,5f);
        if (raycast.collider != null)
        {
            Debug.Log("YSe");
            Debug.Log(raycast.collider.gameObject);

            if (raycast.collider.gameObject == nedeedPos.gameObject)
            {
                collider.enabled = false;
                inRightPos = true;
                transform.position = new Vector3(raycast.collider.gameObject.transform.position.x, raycast.collider.gameObject.transform.position.y - 0.3f, 0);
                FindObjectOfType<CardsGameManager>().remainCards -= 1;
            }
        }
        else
            Debug.Log("No");
    }

    private void Update()
    {
        if (Input.touchCount > 0&& dragging)
        {
            Touch touch = Input.GetTouch(0);
            fingerpos = Camera.main.ScreenToWorldPoint(touch.position);
            transform.position = fingerpos;
        }
           
        
    }

}

