using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [SerializeField] GameObject forceBar, canvasApuntar, camaraBolos;
    [SerializeField] BolaController miBola;

    void Update()
    {
        if (GameManager.Instance.GetFaseJuego() == "faseApuntado")
        {
            HudApuntado(true);
            changeForceBar();
        }

        else
        {
            HudApuntado(false);
        }
    }

    //Toma el valor de la fuerza, le resta su mínimo y se divide entre el máximo menos el mínimo para poder recibir un valor equivalente entre 0 y 1
    void changeForceBar()
    {
        forceBar.GetComponent<Slider>().value = (miBola.force - GameManager.Instance.minForce) / (GameManager.Instance.maxForce - GameManager.Instance.minForce);
    }

    //Muestra u oculta el hud de apuntado dependiendo de la booleana que reciba
    void HudApuntado(bool mostarme)
    {
        canvasApuntar.SetActive(mostarme);
        camaraBolos.SetActive(mostarme);
    }
}
