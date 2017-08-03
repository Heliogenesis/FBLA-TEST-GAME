using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    public List<int> list1 = new List<int>();
    public int MaxLevel = 0;

    private savedata data;

    public void NextLevel()
    {
        MaxLevel = 1;
    }

    private void Start()
    {
        Load();
    }

    private void Update()
    {
        print(MaxLevel);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Save();
        }
    }

    public void Save()
    {
        if (!Directory.Exists (Application.dataPath + "/saves/"))
        {
            Directory.CreateDirectory(Application.dataPath + "/saves/");
        }


        FileStream file = File.Create (Application.dataPath + "/saves/SaveData.dat");
        BinaryFormatter bf = new BinaryFormatter();

        CopySaveData();
        bf.Serialize(file, data);
        file.Close();

    }

    public void CopySaveData()
    {
        data.list1.Clear();

        foreach (int i in list1)
        {
            data.list1.Add(i);
        }
        data.MaxLevel = MaxLevel;
    }

    public void Load()
    {
        if (File.Exists(Application.dataPath + "/saves/SaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath + "/saves/SaveData.dat", FileMode.Open);
            data = (savedata)bf.Deserialize(file);
            CopyLoadData();
            file.Close();
        }
    }

    public void CopyLoadData()
    {
        list1.Clear();
        foreach(int i in data.list1)
        {
            list1.Add(i);
        }

        MaxLevel = data.MaxLevel;


    }
}

[System.Serializable]

public class savedata
{
    public List<int> list1 = new List<int>();
    public int MaxLevel;
}