using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Instellingen : MonoBehaviour
{
    public static Slider slider;

    public static float cameraSmoothness = 1.009f;
    public void Update()
    {
        PlayerPrefs.SetFloat("cameraSmoothness", cameraSmoothness);
        PlayerPrefs.Save();
        CameraSlide();
        slider.value = cameraSmoothness;
    }

    private void Awake()
    {
        slider = GameObject.Find("Smoothness").GetComponent<Slider>();
        slider.value = cameraSmoothness;
    }
    public static void LoadSettings()
    {
        cameraSmoothness = PlayerPrefs.GetFloat("cameraSmoothness");
    }
    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("cameraSmoothness", cameraSmoothness);
        PlayerPrefs.Save();
        slider.value = cameraSmoothness;
    }

    //pakt de value van de slider
    public void CameraSlide()
    {
        slider = GameObject.Find("Smoothness").GetComponent<Slider>();
        cameraSmoothness = slider.value;
    }

}
