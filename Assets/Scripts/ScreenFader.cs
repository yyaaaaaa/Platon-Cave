using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScreenFader : MonoBehaviour
{
    Image bg;
    private GameManager gm;

    void Start()
    {
        bg = GetComponent<Image>();
        gm = FindObjectOfType<GameManager>();
    }

public void Fading()
    {
        StartCoroutine(c_Alpha(1.0f, 3.0f));
        Debug.Log("Started");
    }

    IEnumerator c_Alpha(float value, float time)
    {
        float k = 0.0f;
        Color c0 = bg.color;
        Color c1 = c0;
        c1.a = value;

        while ((k += Time.deltaTime) <= time)
        {
            bg.color = Color.Lerp(c0, c1, k / time);

            yield return null;
        }
        bg.color = c1;
    }
}