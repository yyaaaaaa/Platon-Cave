using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    private GameManager gm;
    private AudioSource source;
    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            Instantiate(gameObject, new Vector2(0, -1), Quaternion.identity);
            Destroy(gameObject);

        }
    }
    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketHeight)
    {
        return (ballPos.x - racketPos.x) / racketHeight;
    }
   private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Breakable"))
            source.PlayOneShot(source.clip);

        if (col.gameObject.CompareTag("Recoil")|| col.gameObject.CompareTag("Ball"))
        {
            source.PlayOneShot(source.clip);
            // Calculate hit Factor
            float x = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.x);
            
            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(x, 1).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
            
        }

        
    }


  
}
