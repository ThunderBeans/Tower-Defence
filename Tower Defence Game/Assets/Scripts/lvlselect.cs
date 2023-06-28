using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvlselect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void lvl1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void lvl2()
    {
        SceneManager.LoadScene("Level");
    }
    public void mainmenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
