using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _MenuPrincipal : MonoBehaviour
{
    public GameObject MenuInicial;

    public void IniciarJuego()
    {
        SceneManager.LoadScene(1);
    }

    public void FinalizarJuego()
    {
        Application.Quit();
    }
}
