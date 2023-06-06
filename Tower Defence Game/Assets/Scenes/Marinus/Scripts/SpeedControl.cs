//using System.Collections;
//using System.Collections.Generic;
//using System.ComponentModel;
//using UnityEngine;
//using UnityEngine.UI;

//public class SpeedControl : MonoBehaviour
//{
//    public static bool spedUp = false;
//    public static Image speedControlButton;
//    public static Sprite Speed1;
//    public static Sprite Speed2;

//    private void Start()
//    {
//        speedControlButton = gameObject.GetComponent<Image>();
//        Speed1 = speedControlButton.sprite;
//    }

//    public void ToggleTime()
//    {
//           spedUp = !spedUp;
//    }

//    private void Update()
//    {
//        if (spedUp)
//        {
//            Time.timeScale = 3.0f;
//            speedControlButton.sprite = Speed2;
//            print(Time.timeScale);
//        }
//        else if (!spedUp)
//        { 
//            Time.timeScale = 1.0f;
//            speedControlButton.sprite = Speed1;
//            print(Time.timeScale);
//        } 
        
//    }
//}
