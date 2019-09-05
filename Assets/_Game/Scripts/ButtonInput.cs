using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInput : MonoBehaviour
{
    //public enum Button
    //{
    //    left,
    //    right
    //}

    //public bool left;
  //  public Button button;

    // deklarera 2st event 
    public delegate void ButtonPressed();
    public static event ButtonPressed OnLeft;
    public static event ButtonPressed OnRight;



#if UNITY_EDITOR
	    void Update()
		{
	        if( Input.GetMouseButtonDown(0))
			{
				Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

				RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);


				if (OnLeft != null && hit.collider != null && hit.collider.tag == "Left")
				{
					OnLeft();

				}
				else if (OnRight != null && hit.collider != null && hit.collider.tag == "Right")
				{
					OnRight();
				}

			}
		}
#elif (UNITY_IOS || UNITY_ANDROID)

	void Update()
	{
		foreach (Touch touch in Input.touches)
		{
			if (touch.phase == TouchPhase.Began)
			{
				Debug.Log("test");

				Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);

				RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);


				if (OnLeft != null && hit.collider != null && hit.collider.tag == "Left")
				{
					OnLeft();

				}
				else if (OnRight != null && hit.collider != null && hit.collider.tag == "Right")
				{
					OnRight();
				}
			}
		}
	}

#endif
}
