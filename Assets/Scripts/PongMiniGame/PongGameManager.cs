using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PongGameManager : MonoBehaviour
{
    public GameObject cube;
    public GameObject cube2;
    [SerializeField] private CellN[] cubes;
    public string text;
    public string text2;
    protected Dialogue[] UI;
    protected TextMeshProUGUI message;
    private GameManager gm;
    private Hint hintobj;
    public int needcells = 3;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        UI = Resources.FindObjectsOfTypeAll<Dialogue>();
        message = UI[0].GetComponentInChildren<TextMeshProUGUI>();
        gm = FindObjectOfType<GameManager>();
        CreateLevel();
        cubes = FindObjectsOfType<CellN>();
            UI[0].gameObject.SetActive(true);
            message.text = text;
        hintobj = FindObjectOfType<Hint>();
        hintobj.GetComponent<Object>().text =
           "Нужно собрать телескоп.Мне нужны линзы, трубка и подставка.";
    }
    private void Update()
    {
        if (UI[0].gameObject.activeInHierarchy)
        {
            Time.timeScale = 0f;
        }
        else Time.timeScale = 1f;
        if (needcells <= 0)
        {
            if (!UI[0].gameObject.activeInHierarchy)
                gm.ChangeScene("TableNear");
            UI[0].gameObject.SetActive(true);
            message.text = text2;
           
        }
    }

    private void CreateLevel()
    {

        for (float y = 0.75f; y <= 4.5f; y +=0.75f)
        {
            for (float x = -7f; x <= 7f; x += 0.75f)
            {
                if (x != 4.25f && y != 3.75f || x != -4f && y != 3f)
                    Instantiate(cube, new Vector2(x, y), Quaternion.identity);
                else
                    Instantiate(cube2, new Vector2(x, y), Quaternion.identity);
            }
        }
    }
}
