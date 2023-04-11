using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirCamara : MonoBehaviour
{
    public static GameObject objetivo;
    [Header("Configurar en Editor")]
    public float suavizado = 0.05f;
    public Vector2 limiteXY = Vector2.zero;

    [Header("Configuracion Dinamica")]
    public float camZ;

    private void Awake()
    {
        camZ = this.transform.position.z;
    }

    private void FixedUpdate()
    {
        Vector3 destino;

        if(objetivo == null)
        {
            destino = Vector3.zero;
        }
        else
        {
            destino = objetivo.transform.position;
            if(objetivo.tag == "Bala")
            {
                bool sleeping = objetivo.GetComponent<Rigidbody>().IsSleeping();
                if (sleeping)
                {
                    objetivo = null;
                    destino = Vector3.zero;
                    Canon.bloqueado = false;
                    return;
                }
            }
        }
        destino.x = Mathf.Max(limiteXY.x, destino.x);
        destino.y = Mathf.Max(limiteXY.y, destino.y);
        destino.z = camZ;
        transform.position = destino;
        Camera.main.orthographicSize = destino.y + 20;
    }
}
