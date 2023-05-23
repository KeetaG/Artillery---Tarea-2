using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorJuego : MonoBehaviour
{
    public static AdministradorJuego SingletonAdministradorJuego;
    public static float VelocidadBola = 1f;
    public static int DisparosPorJuego = 3;
    public static float VelocidadRotacion = 1;
    public GameObject canvasGanar;
    public GameObject canvasPerder;
    private void Awake()
    {
        if (SingletonAdministradorJuego == null)
        {
            SingletonAdministradorJuego = this;
        }
        else
        {
           Debug.LogError("Ya existe una instancia en esta clase");
        }
    }
    private void Update()
    {
        if(DisparosPorJuego < 0)
        {
            PerderJuego();
        }
    }

    public void GanarJuego()
    {
        canvasGanar.SetActive(true);
    }

    public void PerderJuego()
    {
        canvasPerder.SetActive(true);
    }

    public void CambiarVelocidad(float nuevaVelocidad)
    {
        VelocidadBola = nuevaVelocidad;
    }

}
