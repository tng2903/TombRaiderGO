using UnityEngine;
using System.Collections;

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
