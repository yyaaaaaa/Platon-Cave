using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransfertoCut : MonoBehaviour
{
    private ScreenFader img;
    private GameManager gm;
    private void Awake()
    {
        img = FindObjectOfType<ScreenFader>();
        gm = FindObjectOfType<GameManager>();
    }
    private  void OnMouseDown() 
    {
        img.Fading();
        Debug.Log("Yea");
    }
    IEnumerator Change()
    {
        gm.ChangeScene("CardGameMoon");
        yield return new WaitForSeconds(3f);
        
        
    }
}
