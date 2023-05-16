using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public GameObject particulasExplosion;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            Invoke("Explotar", 3);
        }
        if (collision.gameObject.tag == "Obstaculo" || collision.gameObject.tag == "Enemigo") Explotar();
    }
    public void Explotar() 
    {
        GameObject particulas = Instantiate(particulasExplosion, transform.position, Quaternion.identity) as GameObject;
        Canon.bloqueado = false;
        SeguirCamara.objetivo = null;
        Destroy(this.gameObject);
    }

}
