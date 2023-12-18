using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour, IXMLDataHandlerer
{
    public float width, height;
    Vector2 vector;

    public GameObject zombik;
    public int zombikStartDelay, zombikRepeatRate;
    public int zombieCount;

    public GameObject slunicko;
    public int slunickoStartdelay, slunickoRepeatRate;

    GameObject go;
    public static Coroutine cor;

    void Start()
    {
        vector = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        width = vector.x;
        height = vector.y;

        //spawn slunicka
        InvokeRepeating("SpawnSlunicko", slunickoStartdelay, slunickoRepeatRate);

        //spawn zombiky
        InvokeRepeating("SpawnZombik", zombikStartDelay, zombikRepeatRate);
    }

    public void Load(LevelData data)
    {
        zombieCount = data.zombieCount;
        Debug.Log("load zombiku" + zombieCount);
    }

    public void SpawnZombik()
    {
        if(zombieCount > 0)
        {
            go = Instantiate(zombik, new Vector2(width, (height - (Random.Range(1, 6) * (GameObject.Find("Background").transform.lossyScale.y / 6)))), gameObject.transform.rotation, GameObject.Find("Background").transform);
            
            zombieCount--;
            Debug.Log(zombieCount);
        }
        else
        {
            cor = StartCoroutine(CallNextLvl());
            CancelInvoke("SpawnZombik");
        }
        
    }
    IEnumerator  CallNextLvl()
    {
        while (GameObject.Find("LevelManager").GetComponent<LevelManager>().CheckForNextLevel() == false)
        {
            GameObject.Find("LevelManager").GetComponent<LevelManager>().CheckForNextLevel();
            Debug.Log("huraa");

            yield return null;
        }
        Debug.Log("koneec");
        
    }
    void SpawnSlunicko()
    {
        go = Instantiate(slunicko, new Vector2(Random.Range(-width+5, width), height), gameObject.transform.rotation, GameObject.Find("Background").transform);
        go.GetComponent<SunMovement>().isFromFlower = false;
    }
}
