using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CarregaCutscene : MonoBehaviour
{

    [SerializeField] GameObject UI;
    [SerializeField] bool Ramificacao;

    private void Start()
    {
        Ramificacao = false;
        UI.SetActive(false);
    }

    public void CutsceneSim()
    {
        SceneManager.LoadSceneAsync("CutsceneBoa");
    }

    public void CutsceneNao()
    {
        SceneManager.LoadSceneAsync("CutsceneRuim");
    }

}
