using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour, IDataPersistance
{
    public LevelDatabase levelDatabase;
    public static LevelManager Instance;

    public void Start()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
            CompleteDatabase(levelDatabase.lvls.Count);
            LoadLevel(1);

        }
        else
        {
            Destroy(gameObject);

        }
    
    }
    public void LoadDatabase(LevelDatabase dat)
    {
        levelDatabase = dat;
    }
    public void LoadSave(Save save)
    {
        LoadLevel(save.lvl);
    }
    public void SaveSave(ref Save save)
    {
        save.lvl = GameObject.Find("LevelManager").GetComponent<LevelDataProcessor>().CurrentLevel();
    }
    public void LoadLevel(int index)
    {
        XMLSave currSave = levelDatabase.lvls[index - 1];

        GameObject.Find("LevelManager").GetComponent<LevelDataProcessor>().LoadData(currSave);

    }
    public void NextLevel()
    {
        Debug.Log("jee");
        try
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            LoadLevel(GameObject.Find("LevelManager").GetComponent<LevelDataProcessor>().levelData.levelIndex + 1);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
    public bool CheckForNextLevel()
    {
        Debug.Log(GameObject.FindGameObjectsWithTag("Zombie").Length);
        
        if (GameObject.FindGameObjectsWithTag("Zombie").Length == 0)
        {
            NextLevel();

            return true;
        }
        else
        {
            return false;
        }
    }
    public void CompleteDatabase(int datCount)
    {

        foreach (string s in levelDatabase.lvls[0].newUnlockedPlants)
        {
            levelDatabase.lvls[0].unlockedPlants.Add(s);
        }

        for (int i = 1; i < datCount; i++)
        {
            foreach (string s in levelDatabase.lvls[i - 1].unlockedPlants)
            {
                levelDatabase.lvls[i].unlockedPlants.Add(s);
            }

            foreach(string s in levelDatabase.lvls[i].newUnlockedPlants)
            {
                levelDatabase.lvls[i].unlockedPlants.Add(s);
            }
        }
    }
}
