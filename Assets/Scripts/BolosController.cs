using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolosController : MonoBehaviour
{
    public Transform[] posicionBolo;
    [SerializeField] GameObject boloPrefab;
    
    void Start()
    {
        ResetBolos();
    }

    void Update()
    {
        
    }

    void ResetBolos()
    {
        for (int i = 0; i < posicionBolo.Length; i++)
        {
            Instantiate(boloPrefab, posicionBolo[i].position, Quaternion.identity);
        }
    }
}
