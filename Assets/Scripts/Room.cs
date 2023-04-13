using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    private GameManager gm;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        gm.OnSceneLoaded();
    }
}
