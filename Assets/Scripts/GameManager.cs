using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    public static GameManager Instance
    {
        get { return instance; }
    }

    public enum GameState { faseApuntado, faseTiro, faseRecogida, fasePartidaAcabada, faseMenu }
    string faseJuego;
    static int numeroBolosCaidos = 0;
    public bool puedoRecoger;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        ChangeFaseJuego(0);
    }

    public void BolosCaidos()
    {
        numeroBolosCaidos++;
    }

    public int GetNumBolosCaidos()
    {
        return numeroBolosCaidos;
    }

    public void ResetCantidadBolos()
    {
        numeroBolosCaidos = 0;
    }

    public string GetFaseJuego()
    {
        return faseJuego;
    }

    public void ChangeFaseJuego(int numeroFase)
    {
        switch (numeroFase)
        {
            case 0:
                faseJuego = "faseApuntado";
                break;

            case 1:
                faseJuego = "faseTiro";
                break;

            case 2:
                faseJuego = "faseRecogida";
                break;

            case 3:
                faseJuego = "faseFinal";
                break;

            case 4:
                faseJuego = "faseMenu";
                break;

            default:
                break;
        }

        Debug.Log(faseJuego);
    }
}
