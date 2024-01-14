using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMovement : MonoBehaviour
{
    //klidne by to mohlo byt v Move.cs, ale uz je to tady, tak to tady i zustane

    private Rigidbody2D rb;
    public bool isFromFlower;
    public float speed;

    public int fallCount;
    public string index;

    public Collider2D coll;

    string name2;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (isFromFlower)
        {
            //pri spawnuni slunicka slunecnici se vystreli v random smeru. Pouzivam floaty, pac je to pak rozmanitejsi
            rb.AddForce(new Vector2(Random.Range(-1.5f, 1.5f), Random.Range(5f, 7f)), ForceMode2D.Impulse);
            index = gameObject.transform.parent.parent.name.Substring(4);
            name2 = "TileFloor" + index;

            coll = gameObject.transform.parent.parent.Find(name2).GetComponent<Collider2D>();
        }
        else
        {
            rb.gravityScale = 0;
            rb.mass = 0;
            fallCount = Random.Range(0, 5);

            StartCoroutine(Fall());
        }
    }
    IEnumerator Fall()
    {
        if (isFromFlower == false)
        {
            transform.Translate(Vector2.down * Time.deltaTime * speed);
        }
        yield return new WaitForEndOfFrame();

        StartCoroutine(Fall());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isFromFlower)
        {
            if (collision == coll)
            {
                rb.velocity = Vector2.zero;
                rb.position = rb.position;
                rb.gravityScale = 0;
            }
        }
        else if (isFromFlower == false && collision.gameObject.CompareTag("Ground"))
        {
            if(fallCount == 0)
            {
                StopAllCoroutines();
                rb.velocity = Vector2.zero;
                rb.position = rb.position;

                StartCoroutine(Timer());
            }
            else
            {
                fallCount--;
            }
        }        
    }
    IEnumerator Timer()
    {
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSecondsRealtime(1f);
        }

        Destroy(gameObject);
    }
}
