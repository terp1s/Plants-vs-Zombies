using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PutDown : MonoBehaviour
{
    
    public bool isMouse;
    public bool hasPlant = false;
    public GameObject plantFlw;
    public GameObject bgr;

    private void Awake()
    {
        enabled = false;
        bgr = GameObject.Find("Background");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (GetComponent<BoxCollider2D>().OverlapPoint(mousePosition) && hasPlant == false)
            {
                plantFlw.GetComponent<FollowMouse>().enabled = false;
                plantFlw.transform.position = transform.position;
                plantFlw.transform.parent = transform.parent;
                plantFlw.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                plantFlw.GetComponent<SpriteRenderer>().sortingLayerName = "Plants";
                plantFlw.GetComponent<SpriteRenderer>().sortingOrder = 0;
                hasPlant = true;



                foreach (Transform child in bgr.transform)
                {
                    foreach (Transform child2 in child.transform)
                    {

                        if (child2.GetComponent<PutDown>() != null)
                        {
                            child2.GetComponent<PutDown>().enabled = false;
                            child2.GetComponent<PutDown>().plantFlw = null;
                        }

                    }


                }
            }


        }
    }
    private void OnMouseExit()
    {
        isMouse = false;
    }

}
