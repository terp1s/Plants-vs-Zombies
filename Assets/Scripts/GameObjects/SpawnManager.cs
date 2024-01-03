using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour, IXMLDataHandlerer
{
    public GameObject levelManager;
    public GameObject bgrSquare;
    public GameObject Background;

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
        vector = bgrSquare.transform.localScale;
        width = vector.x;
        height = vector.y;   
    }

    public void Load(LevelData data)
    {
        zombieCount = data.zombieCount;

        //spawn slunicka
        InvokeRepeating("SpawnSlunicko", slunickoStartdelay, slunickoRepeatRate);

        //spawn zombiky
        InvokeRepeating("SpawnZombik", zombikStartDelay, zombikRepeatRate);
    }
    public void SpawnZombik()
    {
        if(zombieCount > 0)
        {
            go = Instantiate(zombik, Background.transform);
            go.transform.position = new Vector2(width + 1, height - ((Random.Range(1, 6) - 0.4f) * (bgrSquare.transform.lossyScale.y / 5)));

            zombieCount--;
        }
        else
        {
            cor = StartCoroutine(CallNextLvl());
            CancelInvoke("SpawnZombik");
        }
    }
    IEnumerator  CallNextLvl()
    {
        while (LevelManager.Instance.CheckForNextLevel() == false)
        {
            LevelManager.Instance.CheckForNextLevel();

            yield return null;
        }
    }
    void SpawnSlunicko()
    {
        go = Instantiate(slunicko, new Vector2(Random.Range(-width + 5, width), height + 3), gameObject.transform.rotation, Background.transform);
        go.GetComponent<SunMovement>().isFromFlower = false;
    }
}
