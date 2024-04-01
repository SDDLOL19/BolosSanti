using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneController : MonoBehaviour
{
    //Para cargar el nivel de la bolera
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    //Para salir del juego
    public void EndGame()
    {
        Application.Quit();
    }
}
