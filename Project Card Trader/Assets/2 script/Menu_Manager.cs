using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Manager : MonoBehaviour
{
    public AudioSource button;

    public void Playgame()
    {
        button.Play();
        //SceneManager.LoadScene(1);0
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }  
    
    public void MainMenu()
    {
        button.Play();
        //SceneManager.LoadScene(1);0
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Restart()
    {
        button.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void Quitgame()
    {
        button.Play();
        Application.Quit();
    }
}
