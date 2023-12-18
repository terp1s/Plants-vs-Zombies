using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildSpawn : MonoBehaviour
{
    public GameObject child;
    public float repeatRate;
    public float startDelay;


    // Start is called before the first frame update
    void Start()
    {
       //opakovany spawn po urcitem case
       InvokeRepeating("Spawn", startDelay, repeatRate);
    }
    void Spawn()
    {
        GameObject go = Instantiate(child, gameObject.transform.position , gameObject.transform.rotation, gameObject.transform);

        if (go.CompareTag("Sun"))
        {
            go.GetComponent<SunMovement>().isFromFlower = true;
        }

    }
}
