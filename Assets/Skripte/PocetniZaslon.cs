using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PocetniZaslon : MonoBehaviour
{
    [SerializeField] string gameplaySceneName = "PurrfectMess";

    public void PlayGame()
    {
        SceneManager.LoadScene(gameplaySceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}