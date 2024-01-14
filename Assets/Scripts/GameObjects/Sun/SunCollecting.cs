using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SunCollecting : MonoBehaviour
{
    public GameObject score;
    public int scoreValue;
    void Start()
    {
        score = GameObject.Find("Score");
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            if (GetComponent<BoxCollider2D>().OverlapPoint(mousePosition))
            {
                scoreValue = int.Parse(score.GetComponent<TMP_Text>().text);
                Destroy(gameObject);
                scoreValue += 25;
                score.GetComponentInChildren<TMP_Text>().text = scoreValue.ToString();
            }
        }
    }
}
