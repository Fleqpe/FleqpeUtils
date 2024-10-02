using UnityEngine;

public class LanguageDisplayer : MonoBehaviour
{
    public int localeID;
    public void ChangeLocale()
    {
        LanguageManager.Instance.ChangeLocale(localeID);
    }
}
