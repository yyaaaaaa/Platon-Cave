using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CardsGameManager : MonoBehaviour
{
    private Dialogue[] UI;
    private TextMeshProUGUI message;
    private GameManager gm;
    public int remainCards = 5;
    [SerializeField] string text;
    [SerializeField] string text2;
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        UI = Resources.FindObjectsOfTypeAll<Dialogue>();
        message = UI[0].GetComponentInChildren<TextMeshProUGUI>();
        gm = FindObjectOfType<GameManager>();
        UI[0].gameObject.SetActive(true);
        message.text = text;
    }
    private void Update()
    {

        if (remainCards <= 0)
        {
            if (!UI[0].gameObject.activeInHierarchy)
                gm.ChangeScene("Cutscene3");
            UI[0].gameObject.SetActive(true);
            message.text = text2;

        }
    }
}
