using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public bool FacingRight=true;
    public Vector2 objpos = new Vector2(0,0);
    private void Update()
    {
        if(objpos.x < transform.position.x && FacingRight)
        {
            Flip();
        }
        else if(objpos.x > transform.position.x && !FacingRight)
        {
            Flip();
        }
    if(objpos!= new Vector2(0,0))
        {
         //Move to object
        }
    }
    private void Flip()
    {
        FacingRight = !FacingRight;
        Vector2 localScale = gameObject.transform.localScale;

        localScale.x *= -1;

        transform.localScale = localScale;
    }
    
}
