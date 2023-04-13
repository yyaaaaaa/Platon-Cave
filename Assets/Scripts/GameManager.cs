using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private List<string> objnames;
    [SerializeField] private string sceneName;
    [SerializeField] private int numberOfObjs;
    [SerializeField] private string lastTip;
    public void SetHint(string hint)
    {
        lastTip = hint;
    }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }

    public void OnSceneLoaded()
    {
        sceneName = SceneManager.GetActiveScene().name;
        objnames = CeepDestroying.GetObjs();
        for (int i = 0; i < objnames.ToArray().Length; i++)
        {
            GameObject obj = GameObject.Find(objnames[i]);
            Destroy(obj);
        }
        numberOfObjs = objnames.Count;
        for (int i = 0; i < numberOfObjs; i++)
        {
            PlayerPrefs.SetString("object_" + i, objnames[i]);
        }
        PlayerPrefs.SetString("SceneName", sceneName);
        PlayerPrefs.SetInt("NumberOfObj", numberOfObjs);
        PlayerPrefs.SetString("LastTip", lastTip);
        PlayerPrefs.Save();
    }
    public void SetValues(string sceneNamee, int numberOfObjss, string lastTipp,List<string> objnamess)
    {
        numberOfObjs = numberOfObjss;
        sceneName = sceneNamee;
        lastTip = lastTipp;
        for(int i = 0; i < numberOfObjss; i++)
        {
            objnames.Add(objnamess[i]);
        }
    }
}
