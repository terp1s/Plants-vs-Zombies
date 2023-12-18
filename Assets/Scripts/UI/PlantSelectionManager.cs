using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSelectionManager : MonoBehaviour, IXMLDataHandlerer
{
    List<GameObject> plants;
    public List<GameObject> UIs;

    void Display()
    {
        int i = 0;

        foreach(GameObject plant in plants)
        {
            Debug.Log(plant);   
            string naame = plant.name + "UI";
            Instantiate(UIs.Find(item => item.name == naame), this.transform.position + new Vector3(50 * i, 0), Quaternion.identity, this.transform);
            i++;
        }
    }
    public void Load(LevelData data)
    {
        plants = data.unlockedPlants;
        Debug.Log(plants[0].name);
        Display();
    }
}
