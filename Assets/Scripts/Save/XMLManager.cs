using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using UnityEngine.UIElements;

public class XMLManager : MonoBehaviour
{
    public static XMLManager instance;
    public LevelDatabase levelDatabase;

    private void Awake()
    {
        instance = this;
        levelDatabase = Load();
        GameObject.Find("LevelManager").GetComponent<LevelManager>().LoadDatabase(levelDatabase);

    }

    private void Start()
    {
    }

    public LevelDatabase Load()
    {
        string dirPath = Path.Combine(Application.dataPath, "StreamingFiles");
        Directory.CreateDirectory(dirPath);

        string fullPath = Path.Combine(dirPath, "level_data.xml");

        if (!File.Exists(fullPath))
        {
            File.Create(fullPath);
        }

        XmlSerializer serializer = new XmlSerializer(typeof(LevelDatabase));
        FileStream filestream = new FileStream(fullPath, FileMode.Open);
        levelDatabase = serializer.Deserialize(filestream) as LevelDatabase;

        //FileStream filesave = new FileStream(fullPath, FileMode.Create);
        //LevelDatabase lvl = new LevelDatabase();
        //XMLSave save = new XMLSave();
        //save.lvl = 1;
        //save.zombieCount = 1;
        //save.Zombies = new List<string> { "Zombie" };
        //save.newUnlockedPlants = new List<string> { "Peaflower" };
        //lvl.Add(save);
        //serializer.Serialize(filesave, lvl);

        return levelDatabase;
    }

    
}


