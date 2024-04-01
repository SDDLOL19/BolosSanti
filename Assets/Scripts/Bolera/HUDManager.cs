using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [SerializeField] GameObject forceBar, inputInfo;
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

    void changeForceBar()
    {
        forceBar.GetComponent<Slider>().value = (miBola.force - 20) / 80;
    }

    void HudApuntado(bool mostarme)
    {
        forceBar.SetActive(mostarme);
        inputInfo.SetActive(mostarme);
    }
}
