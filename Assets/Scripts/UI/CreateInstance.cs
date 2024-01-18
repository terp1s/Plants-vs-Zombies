using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreateInstance : MonoBehaviour
{
    public GameObject kyticka;
    public GameObject love;
    public GameObject bgr;
    public int price;
    public AudioClip buy;

    public GameObject go;

    private void Start()
    {
        bgr = GameObject.Find("Background");
        love = GameObject.Find("Score");
    }
    public void OnClick(GameObject prefab)
    {
        if (int.Parse(love.GetComponentInChildren<TMP_Text>().text) >= price && !LevelDataProcessor.Instance.isPutEnabled)
        {
            int loveCurr = int.Parse(love.GetComponentInChildren<TMP_Text>().text);
           
            love.GetComponentInChildren<TMP_Text>().text = (loveCurr - price).ToString();

            kyticka = Instantiate(prefab, bgr.transform);
            kyticka.transform.position = gameObject.transform.position;

            if (kyticka.gameObject.GetComponent<ChildSpawn>() == true)
            {
                kyticka.gameObject.GetComponent<ChildSpawn>().enabled = false;

            }
            kyticka.gameObject.GetComponent<FollowMouse>().enabled = true;
            kyticka.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            kyticka.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "MovingObjects";
            kyticka.GetComponent<SpriteRenderer>().sortingOrder = 1;
            LevelDataProcessor.Instance.isPutEnabled = true;

            SoundManager.instance.PlaySound(buy);
        }
    }
}
