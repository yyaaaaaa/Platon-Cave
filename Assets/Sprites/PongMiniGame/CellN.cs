using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellN : Cell
{
    private PongGameManager gm;
    private void Awake()
    {
        gm = FindObjectOfType<PongGameManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            gm.needcells -= 1;
            Destroy(gameObject);
        }

    }
}
