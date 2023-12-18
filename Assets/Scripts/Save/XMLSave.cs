using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class XMLSave
{
    public int lvl;
    public List<string> unlockedPlants;
    public List<string> newUnlockedPlants;
    public List<string> Zombies;
    public bool isDay;
    public int zombieCount;

    public XMLSave()
    {
        unlockedPlants = new List<string>();
        newUnlockedPlants = new List<string>();
        Zombies = new List<string>();
       
    }
}
