using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limpiador : MonoBehaviour
{
    Animator myAnimator;
    public bool doneOnce = false;
    int cantidadBolosCaidosRondaAnterior;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        cantidadBolosCaidosRondaAnterior = 0;
    }

    void Update()
    {
        //Si todavía no se ha realizado y está en la faseRecogida comienza el proceso para reestablecer los elementos
        if (!doneOnce && GameManager.Instance.GetFaseJuego() == "faseRecogida")
        {
            doneOnce = true;
            
            //Si la cantidad de bolos cambia, activa el limpiador y se ajusta la cantidad de bolos caidos de la ronda anterior
            if (cantidadBolosCaidosRondaAnterior != GameManager.Instance.GetNumBolosCaidos())
            {
                cantidadBolosCaidosRondaAnterior = GameManager.Instance.GetNumBolosCaidos();
                myAnimator.Play("Clean");
            }
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
