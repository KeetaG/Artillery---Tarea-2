using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public static bool bloqueado;
    public AudioClip clipDisparo;
    private GameObject SonidoDisparo;
    private AudioSource SourceDisparo;
    [SerializeField] private GameObject BalaPrefab;
    public GameObject ParticulasDisparo;
    private GameObject puntaCanon;
    private float rotacion;
    private int disparos;

    private void Start()
    {
        disparos = AdministradorJuego.DisparosPorJuego;
        puntaCanon = transform.Find("PuntaCanon").gameObject;
        SonidoDisparo = GameObject.Find("SonidoDisparo");
        SourceDisparo = SonidoDisparo.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        rotacion += Input.GetAxis("Horizontal") * AdministradorJuego.VelocidadRotacion;
        if (rotacion <= 90 && rotacion >= 0)
        {
            transform.eulerAngles = new Vector3(rotacion, 90, 0.0f);
        }

        if (rotacion > 90) rotacion = 90;
        if (rotacion < 0) rotacion = 0;

        if (Input.GetKeyDown(KeyCode.Space)&&!bloqueado)
        {
           if (disparos > 0)
            {
                GameObject temp = Instantiate(BalaPrefab, puntaCanon.transform.position, transform.rotation);
                Rigidbody tempRB = temp.GetComponent<Rigidbody>();
                SeguirCamara.objetivo = temp;
                Vector3 direccionDisparo = transform.rotation.eulerAngles;
                direccionDisparo.y = 90 - direccionDisparo.x;
                Vector3 direccionParticulas = new Vector3(-90 + direccionDisparo.x, 90, 0);
                GameObject Particulas = Instantiate(ParticulasDisparo, puntaCanon.transform.position, Quaternion.Euler(direccionParticulas));
                tempRB.velocity = direccionDisparo.normalized * AdministradorJuego.VelocidadBola;
                SourceDisparo.Play();
                bloqueado = true;
            }
            disparos--;
        }
        
    
    }
}
