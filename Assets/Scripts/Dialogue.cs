using System.Collections;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
public class Dialogue : MonoBehaviour
{
    private TextMeshProUGUI text;
    private int pages = 0;
    public GameObject hintall;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && hintall==null)
        {
            text.pageToDisplay++;
            pages++;
            if (pages > text.textInfo.pageCount)
            {
                
                gameObject.SetActive(false);
            }
        }
    }
    private void OnEnable()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        pages = 0;
        text.pageToDisplay = 0;
    }

    private void OnDisable()
    {
        text.text = " ";
    }
}
