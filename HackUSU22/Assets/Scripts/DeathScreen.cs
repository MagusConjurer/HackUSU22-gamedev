using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public void RestartGame()
    {
        Scene sc = SceneManager.GetActiveScene();
        SceneManager.LoadScene(sc.name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
