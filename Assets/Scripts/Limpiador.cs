using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limpiador : MonoBehaviour
{
    Animator myAnimator;
    Joint myJoint;
    bool doneOnce = false;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myJoint = GetComponent<Joint>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!doneOnce && GameManager.Instance.GetFaseJuego() == "faseRecogida")
        {
            doneOnce = true;
            myAnimator.Play("Clean");
        }
    }

    //Esta función se ejecuta desde el clip de animación "Clean". Resetea el doneOnce y permite que la bola se resetee
    public void PuedeResetear()
    {
        doneOnce = false;
        GameManager.Instance.puedoRecoger = true;
    }
}
