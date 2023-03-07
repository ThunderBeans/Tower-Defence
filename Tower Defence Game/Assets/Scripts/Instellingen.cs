using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class Instellingen : MonoBehaviour
{
    public static float cameraSmoothness = 1.005f;
    GameObject slider;
    Slider sl;


    private void Awake()
    {   //Pakt de slider van het main menu

    }
    void Update()
    {
        
    }
    //pakt de value van de slider
    public void CameraSlide()
    {
        GameObject slider = GameObject.Find("Smoothness");
        
        Slider sl = slider.GetObjectVariable<Slider>();
        cameraSmoothness = slider.value;
        Debug.Log("Functie " + cameraSmoothness);

        
    }
}
