using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolosManager : MonoBehaviour
{
    public Transform[] posicionBolo;
    [SerializeField] GameObject boloPrefab;
    public bool[] bolosVivos;
    bool spawnOnce = false;

    private void Update()
    {
        if (GameManager.Instance.GetFaseJuego() == "faseApuntado" && !spawnOnce)
        {
            CrearBolos();
            spawnOnce = true;
        }

        else if (GameManager.Instance.GetFaseJuego() == "faseRecogida")
        {
            spawnOnce = false;
        }
    }

    void CrearBolos()
    {
        for (int i = 0; i < posicionBolo.Length; i++)
        {
            if (bolosVivos[i] == true)
            {
                GameObject clonBolo = Instantiate(boloPrefab, posicionBolo[i].position, Quaternion.identity);
                clonBolo.GetComponent<Bolo>().crearBolo(i, this);
            }

            //if (i == posicionBolo.Length - 1)
            //{
                
            //}
        }
    }

    public void BoloTirado(int numero)
    {
        bolosVivos[numero] = false;
    }
}
