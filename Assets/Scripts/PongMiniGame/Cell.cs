
using UnityEngine;

public class Cell : MonoBehaviour
{
    private AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
      if(collision.gameObject.CompareTag("Ball"))
        {
            audio.PlayOneShot(audio.clip);
            Destroy(gameObject);
        }
    }
}
