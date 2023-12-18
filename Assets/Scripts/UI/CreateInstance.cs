using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreateInstance : MonoBehaviour
{
    public GameObject kyticka;
    public GameObject love;
    public int price;

    public GameObject go;

    private void Start()
    {
        love = GameObject.Find("SunScore");
    }
    public void OnClick(GameObject prefab)
    {
        go = GameObject.Find("Background").gameObject.transform.Find("Tile00").gameObject.gameObject.transform.Find("FullTile00").gameObject;

        //&& go.GetComponent<PutDown>() == false

        if (int.Parse(love.GetComponentInChildren<TMP_Text>().text) >= price && go.GetComponent<PutDown>().enabled == false)
        {
            int loveCurr = int.Parse(love.GetComponentInChildren<TMP_Text>().text);
           
            love.GetComponentInChildren<TMP_Text>().text = (loveCurr - price).ToString();

            kyticka = Instantiate(prefab, gameObject.transform.position, Quaternion.identity);
            kyticka.transform.parent = gameObject.transform;
            kyticka.gameObject.GetComponent<FollowMouse>().enabled = true;
            kyticka.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            kyticka.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "MovingObjects";
            kyticka.GetComponent<SpriteRenderer>().sortingOrder = 1;
        }

        
    }

}
