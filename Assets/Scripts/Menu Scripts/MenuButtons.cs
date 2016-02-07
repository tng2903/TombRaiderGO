using UnityEngine;
using System.Collections;


/// <summary>
/// Simple UI script attached to for button clicks (specify string for scene name)
/// </summary>
public class MenuButtons : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
