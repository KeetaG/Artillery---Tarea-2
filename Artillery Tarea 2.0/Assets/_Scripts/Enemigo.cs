using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemigo : MonoBehaviour
{
    public UnityEvent GameWon;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Explosion")
        {
            GameWon.Invoke();
            Destroy(this.gameObject);
        }
    }
}
