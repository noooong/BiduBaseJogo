using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_menu : MonoBehaviour
{
    // Start is called before the first frame update

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Scene 1");
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void Credits()
    {
        SceneManager.LoadSceneAsync("Credits");
    }


}
