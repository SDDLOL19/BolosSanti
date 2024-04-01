using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaController : MonoBehaviour
{
    Rigidbody myRigidbody;
    Vector3 originalPosition;
    [SerializeField] float force, maxTimer, speed, maxPosX, minPosX;
    float timer = 0;
    int timesShot = 0;

    void Start()
    {
        originalPosition = transform.position;
        myRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        switch (GameManager.Instance.GetFaseJuego())
        {
            case "faseApuntado":
                MoverBola();
                break;

            case "faseTiro":
                Temporizador();
                break;

            case "faseRecogida":
                if (GameManager.Instance.puedoRecoger)
                {
                    if (timesShot < 3)
                    {
                        resetBola();
                    }

                    else
                    {
                        GameManager.Instance.ChangeFaseJuego(3);
                    }
                }
                break;

            default:
                break;
        }
    }

    //Vuelve la bola no kinematic para impulsar la bola y cambia la fase de juego a la fase de tiro
    void PushBall()
    {
        myRigidbody.isKinematic = false;
        myRigidbody.AddForce(-transform.forward * force, ForceMode.Impulse);
        timesShot++;
        GameManager.Instance.ChangeFaseJuego(1);
    }

    void MoverBola()
    {
        //Hay que hacer clamp en x para que no se pase de los limites al moverse
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, 0) * Time.deltaTime * speed;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPosX, maxPosX), transform.position.y, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PushBall();
        }
    }

    //Temporizador para iniciar la fase de recogida
    void Temporizador()
    {
        timer += Time.deltaTime;

        if (timer >= maxTimer)
        {
            GameManager.Instance.ChangeFaseJuego(2);
            timer = 0;
        }
    }

    //Vuelve la bola kinematic para detener los efectos de la física, la posiciona y la rota a como estaba en origen
    //Luego cambia la fase a la fase de apuntado
    void resetBola()
    {
        myRigidbody.isKinematic = true;
        transform.position = originalPosition;
        transform.eulerAngles = Vector3.zero;
        GameManager.Instance.ChangeFaseJuego(0);
    }
}
