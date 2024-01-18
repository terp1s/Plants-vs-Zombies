using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CollisionDetector : MonoBehaviour
{
    //detektory ma jenom jedna strana (tady zombici, resp vsechno na jejich strane, jako hroby a takovy veci, uvidim jak daleko se dostanu)

    //gameObject = zombie

    public bool isTouchingPlant = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Paris(Clone)")
        {
            if (collision.gameObject.GetComponent<Animator>().GetBool("HasHead"))
            {
                collision.gameObject.GetComponent<Animator>().SetBool("HasHead", false);
                Destroy(gameObject);
            }
        }
        if (collision.collider.CompareTag("Plant"))
        {
            isTouchingPlant = true;

            StartCoroutine(RepeatDmg(collision));
        }      
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ammo"))
        {
            //Zpusobi si damage a znici munici
            gameObject.GetComponent<HealthManager>().Dmg(other.gameObject.GetComponent<HealthManager>().afflDmg);
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isTouchingPlant = false;
    }
    IEnumerator RepeatDmg(Collision2D collision)
    {
        while (isTouchingPlant)
        {
            collision.collider.gameObject.GetComponent<HealthManager>().Dmg(gameObject.GetComponent<HealthManager>().afflDmg);

            yield return new WaitForSeconds(1.0f);

            StartCoroutine(RepeatDmg(collision));
        }

        yield return null;
    }
}
