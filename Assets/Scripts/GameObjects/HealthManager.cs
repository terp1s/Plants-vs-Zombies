using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    //script pro vsechny bojove objekty (zombici, munice, rostliny), kazda ma zacatecni HP, aktualni HP a eventuelne kolik dmg dela

    public  int currentHealth;
    public int maxHealth;
    public int afflDmg;
    public AudioClip death;
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void Dmg(int dmg)
    {
        // dmg =/= afflDmg pri kolizi se pouziva affDmg ze skriptu collideru
        currentHealth -= dmg;
    }
    public void Update()
    {
        //smrt :((

        if (currentHealth <= 0) 
        {
            if (CompareTag("Plant"))
            {
                gameObject.transform.parent.GetComponentInChildren<PutDown>().hasPlant = false;
            }

            SoundManager.instance.PlaySound(death);
            Destroy(gameObject);

        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Ghost") && this.tag == "Plant")
        {
            if (this.gameObject.name == "Paris(Clone)")
            {
                if (this.gameObject.GetComponent<Animator>().GetBool("HasHead"))
                {
                    this.gameObject.GetComponent<Animator>().SetBool("HasHead", false);
                    Destroy(collision.gameObject);
                }
                else
                {
                    StartCoroutine(GetDmg(collision.gameObject.GetComponent<HealthManager>().afflDmg));
                }
            }
            else
            {
                StartCoroutine(GetDmg(collision.gameObject.GetComponent<HealthManager>().afflDmg));
            }
        }

        if(this.gameObject.CompareTag("Ghost") && collision.collider.name == "Paris(Clone)")
        {
            StartCoroutine(GetDmg(collision.gameObject.GetComponent<HealthManager>().afflDmg));
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ammo") && this.gameObject.CompareTag("Ghost"))
        {
            //Zpusobi si damage a znici munici
            Dmg(other.gameObject.GetComponent<HealthManager>().afflDmg);
            Destroy(other.gameObject);
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        StopAllCoroutines();
    }
    IEnumerator GetDmg(int dmg)
    {
        while (true)
        {
            Dmg(dmg);

            yield return new WaitForSeconds(2f);
        }
    }
}
