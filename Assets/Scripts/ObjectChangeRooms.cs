using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[RequireComponent(typeof(AudioSource))]
public class ObjectChangeRooms : MonoBehaviour
{
    public string sceneName;
    private GameManager gm;
    private AudioSource audio;
    protected Dialogue[] UI;
    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        audio.volume = 0.6f;
        audio.playOnAwake = false;
        UI = Resources.FindObjectsOfTypeAll<Dialogue>();
        gm = FindObjectOfType<GameManager>();
    }
    private void OnMouseDown()
    {
        if (!UI[0].gameObject.activeSelf)
        {
            if(audio.clip!=null)
            StartCoroutine(DelayedLoad());
            else
                gm.ChangeScene(sceneName);
        }
    }

    IEnumerator DelayedLoad()
    {
        //Play the clip once
        audio.Play();

        //Wait until clip finish playing
        yield return new WaitForSeconds(audio.clip.length);
        gm.ChangeScene(sceneName);
    }

}
