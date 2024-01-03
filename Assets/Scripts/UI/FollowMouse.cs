using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    Vector2 mousePos;
    public Transform bgr;

    private void Awake()
    {
        //bgr = GameObject.Find("BackgroundSquare");
        bgr = gameObject.transform.parent;

        enabled = false;

    }

    private void Update()
    {       
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePos.x, mousePos.y);
    }

    private void OnEnable()
    {
        foreach (Transform child in bgr.Find("BackgroundSquare"))
        {
            foreach (Transform child2 in child.transform)
            {
                if(child2.GetComponent<PutDown>() != null)
                {
                    child2.GetComponent<PutDown>().enabled = true;
                    child2.GetComponent<PutDown>().plantFlw = gameObject;
                }               
            }

        }

        LevelDataProcessor.Instance.isPutEnabled = true;
    }
}
