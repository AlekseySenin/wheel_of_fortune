using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveSystem 
{
    public static void SaveScore(int data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save.bin";
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log(path);
    }

    public static int LoadScore()
    {
        Debug.Log("Loading");
        string path = Application.persistentDataPath + "/save.bin";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            int data = (int)formatter.Deserialize(stream);
            stream.Close();
            return data;
        }
        else return 0;
    }
}
