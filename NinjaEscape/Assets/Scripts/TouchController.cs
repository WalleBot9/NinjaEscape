using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public static bool movingUp;
    public bool movingDown;
    public bool movingLeft;
    public bool movingRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("UpArrow"))
                {
                    movingUp = true;
                    Debug.Log("Touched Up!");
                }
                else
                {
                    movingUp = false;
                }
                if (hit.collider.gameObject.CompareTag("DownArrow"))
                {
                    movingDown = true;
                }
                else
                {
                    movingDown = false;
                }
                if (hit.collider.gameObject.CompareTag("LeftArrow"))
                {
                    movingLeft = true;
                }
                else
                {
                    movingLeft = false;

                }
                if (hit.collider.gameObject.CompareTag("RightArrow"))
                {
                    movingRight = true;
                }
                else
                {
                    movingRight = false;
                }    
            }
        }
    }
}
