using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildSpawn : MonoBehaviour
{
    public GameObject child;
    public float repeatRate;
    public float startDelay;
    public GameObject bgr;

    void Start()
    {
       //opakovany spawn po urcitem case
       InvokeRepeating("Spawn", startDelay, repeatRate);

        bgr = GameObject.Find("Background");
    }
    void Spawn()
    {
        GameObject go = Instantiate(child, gameObject.transform.position , gameObject.transform.rotation, bgr.transform);
        go.transform.parent = gameObject.transform;

        if (go.CompareTag("Sun"))
        {
            go.GetComponent<SunMovement>().isFromFlower = true;
        }
    }
}
