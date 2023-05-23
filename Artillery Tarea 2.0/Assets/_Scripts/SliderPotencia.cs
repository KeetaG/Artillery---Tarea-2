using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderPotencia : MonoBehaviour
{
    public Canon canon;
    public Slider sliderPotencia;
    // Start is called before the first frame update
    void Start()
    {
        sliderPotencia = this.GetComponent<Slider>();
        sliderPotencia.onValueChanged.AddListener(delegate { ControlCambios(); });
    }
    public void ControlCambios()
    {
       
    }
}
    
