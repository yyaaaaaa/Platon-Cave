using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Menu : MonoBehaviour
{
    public GameObject dialogue;
    public GameObject mainMenu;
    private string sceneName;
    private string lastTip;
    private int numberofobj;
    private List<string> objs;
    [SerializeField] private GameManager gm;
    [SerializeField]private UI[] UI;
    private AudioPlayerManager audio;
    public AudioClip clip;
    public GameObject hintall;
    private void Awake()
    {
        UI = Resources.FindObjectsOfTypeAll<UI>();
        gm = FindObjectOfType<GameManager>();
        audio = FindObjectOfType<AudioPlayerManager>();
        sceneName = PlayerPrefs.GetString("SceneName");
        if (PlayerPrefs.GetString("LastTip") != "")
            lastTip = PlayerPrefs.GetString("LastTip");
        else
            lastTip = "Мне нужно взять письмо. Оно должно быть на столе.";
         numberofobj = PlayerPrefs.GetInt("NumberOfObj");
         objs = new();
        for (int i = 0; i < numberofobj; i++)
        {
            objs.Add(PlayerPrefs.GetString("object_" + i));
        }
        gm.SetValues(sceneName, numberofobj, lastTip, objs);
        CeepDestroying.SetObjs(objs, numberofobj);
    }
    public void OpenMenu()
    {
        if(!mainMenu.activeInHierarchy&& !dialogue.activeInHierarchy)
        {
            mainMenu.SetActive(true);
        }
    }
 
 public void CloseMenu()
  {
    if(mainMenu.activeInHierarchy)
        {
            mainMenu.SetActive(false);
        }
  }

public void NewGame()
    {
        CloseMenu();
        GameManager gm = FindObjectOfType<GameManager>();
        PlayerPrefs.DeleteAll();
        gm.SetValues("", 0, "", new List<string>());
        CeepDestroying.objs = new();
        audio.GetComponent<AudioSource>().clip = clip;
        audio.GetComponent<AudioSource>().Play();
        gm.ChangeScene("Cutscene");
    }
    public void ContinueGame()
    {
        audio.GetComponent<AudioSource>().clip = clip;
        audio.GetComponent<AudioSource>().Play();
        if (sceneName == "")
        {
            NewGame();
        }
            CloseMenu();

        UI[0].GetComponentInChildren<Hint>().GetComponent<Object>().text = lastTip;
        UI[0].GetComponentInChildren<Dialogue>().GetComponentInChildren<TextMeshProUGUI>().text = lastTip;
        gm.ChangeScene(sceneName);
        if (UI.Length > 0) UI[0].gameObject.SetActive(true);
        if (hintall.activeInHierarchy)
        {
            hintall.SetActive(false);
            Destroy(hintall);
        }

    }
public void ReturnToMainMenu()
    {
        CloseMenu();
        GameManager gm = FindObjectOfType<GameManager>();
        gm.OnSceneLoaded();
        gm.ChangeScene("MainMenu");
        UI[0].gameObject.SetActive(false);
    }

    public void CloseHint()
    {
        if (hintall.activeInHierarchy)
        {
            hintall.SetActive(false);
            Destroy(hintall);
        }
    }
}
