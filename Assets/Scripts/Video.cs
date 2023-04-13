using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;
public class Video : MonoBehaviour
{
    public GameObject arrow;
    public VideoClip[] videoClips;
    private VideoPlayer videoPlayer;
    [SerializeField] private int i = 1;
    private TextMeshProUGUI text;
    private GameManager gm;
    [SerializeField] private UI[] UI;
    [SerializeField] private string sceneName;
    private AudioPlayerManager audio;
    private void Start()
    {
        UI = Resources.FindObjectsOfTypeAll<UI>();
        videoPlayer = GetComponent<VideoPlayer>();
        text = FindObjectOfType<TextMeshProUGUI>();
        gm = FindObjectOfType<GameManager>();
        audio = FindObjectOfType<AudioPlayerManager>();
        audio.GetComponent<AudioSource>().mute = true;
    }
    private void Update()
    {
        if(videoPlayer.isPaused)
        {
            arrow.SetActive(true);
        }
        if(i > videoClips.Length)
        {
            if (UI.Length > 0)
            {
                UI[0].GetComponentInChildren<Hint>().GetComponent<Object>().text = "Мне нужно взять письмо. Оно должно быть на столе.";
                UI[0].gameObject.SetActive(true);
            }
            audio.GetComponent<AudioSource>().mute = false;
            gm.ChangeScene(sceneName); 
        }
    }
    private void OnMouseDown()
    {
        if (!videoPlayer.isPlaying && videoPlayer.isPrepared)
        {
            arrow.SetActive(false);
            i++;
            videoPlayer.clip = videoClips[i];
            videoPlayer.frame = 0;
            text.pageToDisplay = i+1;
            videoPlayer.Play();
        }

    }
}
