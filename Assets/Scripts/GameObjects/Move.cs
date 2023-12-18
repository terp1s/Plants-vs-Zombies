using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //spolecny skript pro vsechen kontinualni pohyb, rozdeluju podle tagu 

    public float speed;
    private float rightBound;
    private float leftBound;
    private float topBound;
    private float bottomBound;

    private Vector2 bgr;

    // Start is called before the first frame update
    void Start()
    {
        bgr = GameObject.Find("Background").transform.lossyScale;

        rightBound = bgr.x / 2;
        leftBound = -bgr.x / 2;
        topBound = (bgr.y / 2) + 5;
        bottomBound = -bgr.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("Zombie"))
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
        else if (gameObject.CompareTag("Ammo"))
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }
        

        Vector2 pos = gameObject.transform.position;

        if (pos.x > rightBound || pos.x < leftBound || pos.y < bottomBound || pos.y > topBound + 5) 
        {
            

            if(gameObject.CompareTag("Zombie") && pos.x < leftBound)
            {
                GameObject.Find("GameManager").GetComponent<GameOver>().gameOver = true;
            }

            Destroy(gameObject);

        }
    }

}
