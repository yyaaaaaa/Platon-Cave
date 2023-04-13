
using UnityEngine;

public class Pong : MonoBehaviour
{

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            // The screen has been touched so store the touch
            //Touch touch = Input.GetTouch(0);
            if ( Input.GetKey(KeyCode.Mouse0))   //touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                Vector3 touchPosition = Input.mousePosition; //Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x,touch.position.y, 10));

                transform.position = new Vector2(touchPosition.x, -4f);
            }



        }

    }
}
