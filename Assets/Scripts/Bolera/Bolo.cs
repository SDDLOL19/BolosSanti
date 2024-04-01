using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolo : MonoBehaviour
{
    public int numeroBolo;
    public BolosManager miManager;
    bool golpeado = false;
    float timer, maxTimer = 3;

    private void Update()
    {
        if (GameManager.Instance.GetFaseJuego() == "faseRecogida")
        {
            StartCoroutine("Destruccion");
        }
    }

    //Temporizador destrucción
    IEnumerator Destruccion()
    {
        yield return new WaitForSeconds(maxTimer);
        GameManager.Instance.puedoRecoger = true;
        Destroy(this.gameObject);
    }

    public void crearBolo(int numero, BolosManager manager)
    {
        miManager = manager;
        numeroBolo = numero;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (GameManager.Instance.GetFaseJuego() == "faseTiro")
        {
            if (golpeado == false && (transform.rotation.eulerAngles.x < -25 || transform.rotation.eulerAngles.x > 25 || transform.rotation.eulerAngles.z < -25 || transform.rotation.eulerAngles.z > 25))
            {
                miManager.BoloTirado(numeroBolo);
                GameManager.Instance.BolosCaidos();
                golpeado = true;
            }
        }
    }
}
