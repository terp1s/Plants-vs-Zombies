using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resizing : MonoBehaviour
{
    float ratio;

    void Start()
    {
        Transform ogParent = gameObject.transform.parent;
        gameObject.transform.SetParent(GameObject.Find("Tile00").transform);
       

        if (gameObject.CompareTag("Zombie"))
        {
            ratio = 1.0f;
        }
        else if (gameObject.CompareTag("Plant"))
        {
            ratio = 1.0f;
        }
        else if (gameObject.CompareTag("Ammo"))
        {
            ratio = 0.25f;
        }
        else if (gameObject.CompareTag("Sun"))
        {
            ratio = 0.5f;
        }

        gameObject.transform.localScale = ratio * new Vector2(1f/6f, 1f/6f);
        gameObject.transform.SetParent(ogParent);
    }
}
