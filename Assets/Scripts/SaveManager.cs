using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization,Formatters.Binary;

public class SaveManager : MonoBehaviour
{
    public list<ScriptableObject> object = new List<ScriptableObject>(); 

    public void SaveScripables(){
        for(int i = 0; i <object.Count; i++){
            FileStream file = File.Create(Application.persistentDatePath+
            string.Format("/{0).dat",i));
            BinaryFormatter binary = new BinaryFormatter();
            var json = JsonUtilities.TOJson(object[i]);
            binary.Serialize(file,json);
            file.Close();
        }

    }

    public void LoadScripables(){
        for(int i = 0; i <object.Count; i++){
            if(File.Exists(Application.persistentDatePath+
            string.Format("/{0).dat",i))
        }


    }
}
