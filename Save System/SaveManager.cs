using UnityEngine;
using System.IO;
using Newtonsoft.Json;
public class SaveManager
{
      public static GameFiles gameFiles = new GameFiles();
      private static string directory = "/SaveData/";
      private static string fileName = "Gamedata.txt";
      public static void Save()
      {
            string dir = Application.persistentDataPath + directory;
            if (!(Directory.Exists(dir)))
                  Directory.CreateDirectory(dir);
            string jsonFile = JsonConvert.SerializeObject(gameFiles, Formatting.Indented);
            File.WriteAllText(dir + fileName, jsonFile);
      }
      //We Save The GameFiles class as Save.json here.
      public static void Load()
      {
            string fullPath = Application.persistentDataPath + directory + fileName;

            if (File.Exists(fullPath))
            {
                  string jsonFile = File.ReadAllText(fullPath);
                  gameFiles = JsonConvert.DeserializeObject<GameFiles>(jsonFile);
            }
            else
                  Save();
      }
}