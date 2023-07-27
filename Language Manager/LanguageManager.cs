using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Newtonsoft.Json;
using System.Threading.Tasks;

public class LanguageManager : MonoBehaviour
{
      public static Dictionary<string, string> languageDictionary = new Dictionary<string, string>();
      
      private async void Awake()
      {
            SetLanguage("EN");
            await Task.Delay(5000);
            SetLanguage("TR");
      }
      public void SetLanguage(string languageName)
      {
            TextAsset json = Resources.Load<TextAsset>("JSON/" + languageName);
            languageDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json.ToString());
      }

}
