using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using UnityEngine.UIElements;
using System.IO.Pipes;

public class XMLManager : MonoBehaviour
{
    public static XMLManager instance;
    public LevelDatabase levelDatabase;
    public LevelManager levelManager;
    public TextAsset leveldata;
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this);
            levelDatabase = Load();
            levelManager.GetComponent<LevelManager>().LoadDatabase(levelDatabase);

            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }  
    }
    public LevelDatabase Load()
    {
        //string dirPath = Path.Combine(Application.dataPath, "StreamingFiles");
        //Directory.CreateDirectory(dirPath);

        //string fullPath = Path.Combine(dirPath, "level_data.xml");

        //if (!File.Exists(fullPath))
        //{
        //    File.Create(fullPath);
        //}

        XmlReader.Create(new MemoryStream(leveldata.bytes));

        XmlSerializer serializer = new XmlSerializer(typeof(LevelDatabase));
        //FileStream filestream = new FileStream(fullPath, FileMode.Open);
        //levelDatabase = serializer.Deserialize(filestream) as LevelDatabase;

        if (leveldata != null)
        {
            using (XmlReader reader = XmlReader.Create(new StringReader(leveldata.text)))
            {
                while (reader.Read())
                {
                    levelDatabase = serializer.Deserialize(reader) as LevelDatabase;
                }
            }
        }
        else
        {
            Debug.LogError("XML file is not assigned.");
        }

        return levelDatabase;
    }
}


