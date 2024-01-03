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
            string naame = plant.name + "UI";
            GameObject go = Instantiate(UIs.Find(item => item.name == naame), this.transform);
            go.transform.localPosition = new Vector2(-70, 175 + (94*i));
            i--;
        }
    }
    public void Load(LevelData data)
    {
        plants = data.unlockedPlants;
        Display();
    }
}
