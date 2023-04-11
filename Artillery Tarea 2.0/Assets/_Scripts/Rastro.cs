using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rastro : MonoBehaviour
{
    [Header("Configurar en editor")]
    public float distanciaMinimaEntrePuntos = 0.1f;

    private LineRenderer linea;
    private GameObject _objetivoLinea;
    private List<Vector3> puntos;
    
    public GameObject objetivoLinea
    {
        get { return (_objetivoLinea); }
        set
        {
            _objetivoLinea = value;
            if(_objetivoLinea != null)
            {
                linea.enabled = false;
                puntos = new List<Vector3>();
                AgregarPunto();
            }
        }
    }

    public Vector3 UltimoPunto
    {
        get
        {
            if(puntos == null)
            {
                return (Vector3.zero);
            }
            return (puntos[puntos.Count - 1]);
        }
    }

    public void AgregarPunto()
    {
        Vector3 punto = _objetivoLinea.transform.position;
        if (puntos.Count > 0 && (punto - UltimoPunto).magnitude < distanciaMinimaEntrePuntos)
        {
            return;
        }
        puntos.Add(punto);
        linea.positionCount = puntos.Count;
        linea.SetPosition(puntos.Count - 1, UltimoPunto);
        linea.enabled = true;
    }

    private void Awake()
    {
        linea = GetComponent<LineRenderer>();
        linea.enabled = false;
        puntos = new List<Vector3>();
    }

    private void FixedUpdate()
    {
        if (_objetivoLinea == null)
        {
            if(SeguirCamara.objetivo != null)
            {
                if(SeguirCamara.objetivo.tag == "Bala")
                {
                    objetivoLinea = SeguirCamara.objetivo;
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }
        AgregarPunto();
        if (SeguirCamara.objetivo == null)
        {
            objetivoLinea = null;
        }
    }
}
