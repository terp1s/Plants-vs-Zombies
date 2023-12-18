using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SunCollecting : MonoBehaviour
{
    public int score;
    void Start()
    {
        score = int.Parse(GameObject.Find("SunScore").GetComponentInChildren<TMP_Text>().text);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            if (GetComponent<BoxCollider2D>().OverlapPoint(mousePosition))
            {
                Destroy(gameObject);
                score += 150;
                GameObject.Find("SunScore").GetComponentInChildren<TMP_Text>().text = score.ToString();
            }
        }
    }
}
