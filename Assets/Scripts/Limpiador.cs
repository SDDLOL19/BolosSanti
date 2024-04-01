using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limpiador : MonoBehaviour
{
    Animator myAnimator;
    Joint myJoint;
    public bool doneOnce = false;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myJoint = GetComponent<Joint>();
    }

    void Update()
    {
        if (!doneOnce && GameManager.Instance.GetFaseJuego() == "faseRecogida")
        {
            doneOnce = true;
            myAnimator.Play("Clean");
        }

        //Resetea el doneOnce en la fase de tiro para que no se repita el clip "clean"
        else if (GameManager.Instance.GetFaseJuego() == "faseTiro")
        {
            doneOnce = false;
        }
    }

    //Esta función se ejecuta desde el clip de animación "Rest". Permite que la bola se resetee
    public void PuedeResetear()
    {
        GameManager.Instance.puedoRecoger = true;
    }
}
