using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuntuacionHud : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI elementoPuntuacion;

    void Update()
    {
        elementoPuntuacion.text = "TU PUNTUACION: " + GameManager.Instance.GetNumBolosCaidos().ToString("D2");
    }
}
