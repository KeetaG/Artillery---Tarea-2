using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _MenuPausa : MonoBehaviour
{
    public GameObject menuPausa;

    public void MostrarMenuPausa()
    {
        menuPausa.SetActive(true);
        
    }

    public void OcultarMenuPausa()
    {
        menuPausa.SetActive(false);
    }

    public void RegresarAPantallaPrincipal()
    {
        SceneManager.LoadScene(0);
    }


}
