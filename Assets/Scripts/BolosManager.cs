using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolosManager : MonoBehaviour
{
    public Transform[] posicionBolo;
    [SerializeField] GameObject boloPrefab;
    
    void Start()
    {
        ResetBolos();
    }

    void ResetBolos()
    {
        for (int i = 0; i < posicionBolo.Length; i++)
        {
            Instantiate(boloPrefab, posicionBolo[i].position, Quaternion.identity);
        }
    }
}
