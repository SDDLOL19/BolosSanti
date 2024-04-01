using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BolosSceneController : MonoBehaviour
{
    private void Update()
    {
        if (GameManager.Instance.GetFaseJuego() == "faseFinal")
        {
            SceneManager.LoadScene(0);
        }
    }
}
