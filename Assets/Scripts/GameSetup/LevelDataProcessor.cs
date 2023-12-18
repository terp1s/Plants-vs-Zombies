using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

public class LevelDataProcessor : MonoBehaviour
{
    public static LevelDataProcessor Instance;
    public LevelData levelData;
    public List<IXMLDataHandlerer> dataPersistanceObjects;
    public List<GameObject> plantsAndZombies;

    public void Awake()
    {
        Instance = this;
        dataPersistanceObjects = FindDataPersistanceObjects();
        levelData = new LevelData();
    }

    public void LoadLevel(int index)
    {
        foreach (IXMLDataHandlerer xMLDataHandlerer in dataPersistanceObjects)
        {
            xMLDataHandlerer.Load(levelData);
        }
    }
    public void LoadData(XMLSave save)
    {
        
        levelData.unlockedPlants = FindInGame(save.unlockedPlants);
        levelData.levelIndex = save.lvl;
        levelData.zombieCount = save.zombieCount;
        levelData.isDay = save.isDay;
        levelData.zombies = FindInGame(save.Zombies);

        
        LoadLevel(levelData.levelIndex);
    }
    public List<GameObject> FindInGame(List<string> list)
    {
        List<GameObject> result = new List<GameObject>();

        foreach(string str in list)
        {
            result.Add(plantsAndZombies.Find(item => item.name == str));
        }
        return result;
    }
    public int CurrentLevel()
    {
        return levelData.levelIndex;
    }
    
    public List<IXMLDataHandlerer> FindDataPersistanceObjects()
    {
        IEnumerable<IXMLDataHandlerer> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IXMLDataHandlerer>();

        return new List<IXMLDataHandlerer>(dataPersistanceObjects);
    }
}
