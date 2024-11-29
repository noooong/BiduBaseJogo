using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePenel;
    // Update is called once per frame
    void Update()
    {

    }

    public void Pause()
    {
        PausePenel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        PausePenel.SetActive(false);
        Time.timeScale = 1;
    }


}
