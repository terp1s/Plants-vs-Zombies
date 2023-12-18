using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{
    [SerializeField]
    public int lvl;
    [SerializeField]
    public List<GameObject> unlockedPlants;
    [SerializeField]
    public string playerName;

    public Save()
    {
        List<GameObject> list = new List<GameObject>();
        lvl = 1;
        playerName = "";

    }
}
