using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public GameObject DeathScreenCanvas;
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        DeathScreenCanvas.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
