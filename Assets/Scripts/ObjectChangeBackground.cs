using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ObjectChangeBackground : Object
{
    public string hint;
    private Hint hintObj;
    private SpriteRenderer background;
    public Sprite changedBackground;
    private new void Awake()
    {
        hintObj = FindObjectOfType<Hint>();
        gm = FindObjectOfType<GameManager>();
        UI = Resources.FindObjectsOfTypeAll<Dialogue>();
        message = UI[0].GetComponentInChildren<TextMeshProUGUI>();
        background = GameObject.FindGameObjectWithTag("BackGround").GetComponent<SpriteRenderer>();
    }
    private new void OnMouseDown()
    {
        if (!UI[0].gameObject.activeSelf)
        {
            if (text != "")
            {
                UI[0].gameObject.SetActive(true);
                message.text = text;
            }

            if (hint != "")
            {
                hintObj.GetComponent<Object>().text = hint;
                gm.SetHint(hint);
            }
            background.sprite = changedBackground;
            CeepDestroying.AddToArray(this.name); ;
            gameObject.SetActive(false);
        }

    }

}
