using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Pobjeda : MonoBehaviour
{
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("PocetniZaslon");
    }
}
