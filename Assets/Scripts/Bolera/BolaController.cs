using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaController : MonoBehaviour
{
    Rigidbody myRigidbody;
    Vector3 originalPosition;
    [SerializeField] float maxTimer, speed, maxPosX, minPosX;
    /*[HideInInspector]*/ public float force = 20;
    float timer = 0;
    int timesShot = 0, signoCambioFuerza = 1;

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
                ChangeForce();
                break;

            case "faseTiro":
                Temporizador();
                break;

            case "faseRecogida":
                if (GameManager.Instance.puedoRecoger)
                {
                    if (timesShot < 3 && GameManager.Instance.GetNumBolosCaidos() < 10)
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

    //Calcula la fuerza enter dos medidas mientras no se haya disparado la bola. Si llega al máximo baja, si llega al mínimo sube
    void ChangeForce()
    {
        if (force >= GameManager.Instance.maxForce)
        {
            signoCambioFuerza = -1;
        }

        else if (force <= GameManager.Instance.minForce)
        {
            signoCambioFuerza = 1;
        }

        force += Time.deltaTime * signoCambioFuerza * 30;
        force = Mathf.Clamp(force, GameManager.Instance.minForce, GameManager.Instance.maxForce);
    }

    //Vuelve la bola no kinematic para impulsar la bola y cambia la fase de juego a la fase de tiro
    void PushBall()
    {
        myRigidbody.isKinematic = false;
        myRigidbody.AddForce(-transform.forward * force, ForceMode.Impulse);
        timesShot++;
        GameManager.Instance.ChangeFaseJuego(1);
        GameManager.Instance.puedoRecoger = false;
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

    //Cambia la fase a la fase de apuntado
    //Luego vuelve la bola kinematic para detener los efectos de la física, la posiciona y la rota a como estaba en origen
    void resetBola()
    {
        GameManager.Instance.ChangeFaseJuego(0);
        myRigidbody.isKinematic = true;
        transform.position = originalPosition;
        transform.eulerAngles = new Vector3(0, 180, 0); //Debido al modelo, para que los tres agujeros se vean de frente hay que rotarlo 180º
    }
}
