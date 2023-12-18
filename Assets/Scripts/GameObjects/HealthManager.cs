using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    //script pro vsechny bojove objekty (zombici, munice, rostliny), kazda ma zacatecni HP, aktualni HP a eventuelne kolik dmg dela

    public  int currentHealth;
    public int maxHealth;

    public int afflDmg;

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
            Destroy(gameObject);
        }
    }

}
