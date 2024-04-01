using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolo : MonoBehaviour
{
    public int numeroBolo;
    public BolosManager miManager;
    bool golpeado = false;
    float timer, maxTimer = 5;

    private void Update()
    {
        if (GameManager.Instance.GetFaseJuego() == "faseRecogida")
        {
            Temporizador();
        }
    }

    //Temporizador destrucción
    void Temporizador()
    {
        timer += Time.deltaTime;

        if (timer >= maxTimer)
        {
            Destroy(this.gameObject);
            timer = 0;
        }
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
