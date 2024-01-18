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
    public float ghostStartDelay, ghostRepeatRate;
    public int ghostCount;
    public int ghostCountHold;

    public GameObject slunicko;
    public float slunickoStartdelay, slunickoRepeatRate;

    GameObject go;
    public static Coroutine cor;
    float round = 1;
    public void Start()
    {
        vector = bgrSquare.transform.localScale;
        width = vector.x;
        height = vector.y;   
    }
    public void Load(LevelData data)
    {
        ghostCount = data.ghostCount;
        ghostCountHold = ghostCount;
        Spawning();
    }
    public void Spawning()
    {
        
        //spawn slunicka
        InvokeRepeating("SpawnSlunicko", slunickoStartdelay, slunickoRepeatRate);

        //spawn zombiky
        Invoke("SpawnGhost", ghostStartDelay);
    }
    public void SpawnGhost()
    {
        if(ghostCount > 0)
        {
            go = Instantiate(zombik, Background.transform);
            go.transform.position = new Vector2(width + 8, height - ((Random.Range(1, 6) - 0.4f) * (bgrSquare.transform.lossyScale.y / 5)));

            ghostCount--;

            if(round < 4)
            {
                ghostRepeatRate = 10f + 20f/round;
            }
            else if (ghostCount < ghostCountHold/3)
            {
                ghostRepeatRate = Random.Range(0, 0.5f);
            }
            else
            {
                ghostRepeatRate = Random.Range(3, 5);
            }

            Invoke("SpawnGhost", ghostRepeatRate);

            round++;
        }
        else
        {
            cor = StartCoroutine(CallNextLvl());
            CancelInvoke("SpawnGhost");
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
