using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[RequireComponent(typeof(AudioSource))]
public class ObjectOneTimeUSe : Object
{
    public string hint;
    private Hint hintObj;
    private AudioSource audio;
    private ObjectChangeRooms[] objects; 
    private new void Awake()
    {
        objects = FindObjectsOfType<ObjectChangeRooms>();
        audio = GetComponent<AudioSource>();
        audio.volume = 0.6f;
        audio.playOnAwake = false;
        hintObj = FindObjectOfType<Hint>();
        gm = FindObjectOfType<GameManager>();
        UI = Resources.FindObjectsOfTypeAll<Dialogue>();
        message = UI[0].GetComponentInChildren<TextMeshProUGUI>();
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
            CapsuleCollider2D collider2D = GetComponent<CapsuleCollider2D>();
            collider2D.enabled = false;
            if (audio.clip!=null)
                StartCoroutine(DelayedLoad());
            else gameObject.SetActive(false);
            CeepDestroying.AddToArray(this.name); ;
        }
       
    }

    IEnumerator DelayedLoad()
    {
        //Play the clip once
        audio.Play();
      for (int i = 0; i < objects.Length; i++)
        {
            objects[i].GetComponent<CapsuleCollider2D>().enabled = false;
        }
        //Wait until clip finish playing
        yield return new WaitForSeconds(audio.clip.length);
        for (int i = 0; i < objects.Length; i++)
        {
            if(!objects[i].GetComponent<PreventUsing>())
            objects[i].GetComponent<CapsuleCollider2D>().enabled = true;
        }
        gameObject.SetActive(false);


    }

}
