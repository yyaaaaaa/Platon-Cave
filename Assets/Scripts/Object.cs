using System.Collections;
using TMPro;
using UnityEngine;
[RequireComponent(typeof(CapsuleCollider2D))]
public class Object : MonoBehaviour
{
    public string text;
    protected Dialogue[] UI;
    protected TextMeshProUGUI message;
    protected GameManager gm;

    protected void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        UI = Resources.FindObjectsOfTypeAll<Dialogue>();
        message = UI[0].GetComponentInChildren<TextMeshProUGUI>();
    }
    public void OnMouseDown()
    {  
        if (!UI[0].gameObject.activeSelf)
        {  
            UI[0].gameObject.SetActive(true);
            message.text = text; 
        }
    }
    
}
