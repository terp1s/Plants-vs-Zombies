using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Move : MonoBehaviour
{
    //spolecny skript pro vsechen kontinualni pohyb, rozdeluju podle tagu 

    public float speed;
    private float rightBound;
    private float leftBound;
    private float topBound;
    private float bottomBound;

    private Camera cam;
    private GameObject bgr;
   

    void Start()
    {
        bgr = GameObject.Find("Background");
        cam = Camera.main;
    }
    void Update()
    {
        if (gameObject.CompareTag("Ghost"))
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
        else if (gameObject.CompareTag("Ammo"))
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }
        
        Vector2 viewPos = cam.WorldToViewportPoint(gameObject.transform.position);

        if (gameObject.CompareTag("Ghost") && viewPos.x < 0.2f)
        {
            GameObject.Find("GameManager").GetComponent<GameOver>().gameOver = true;
        }

        if (viewPos.x > 2f || viewPos.x < 0f || viewPos.y > 1.5f || viewPos.y < 0f)
        {
            Destroy(gameObject);  
        }
    }
}
