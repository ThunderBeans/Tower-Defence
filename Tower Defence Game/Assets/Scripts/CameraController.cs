using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    float speedV = 1500.0f;
    float speedH = 1500.0f;
    public GameObject Camera;
    Rigidbody rb;
    bool inputDetector = true;
    bool esc = true;
    GameObject Op;
    public static GameObject Ob;


    private void Awake()
    {
        Op = GameObject.Find("Main");
        rb = GetComponent<Rigidbody>();
        Ob = GameObject.Find("Options");
    }

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of scene.
        string sceneName = currentScene.name;

        if (sceneName == "MaxScene")
        {
                esc = false;
                Ob.SetActive(false);
                Op.SetActive(false);
        }
    }

    void Update()
    {
        // toggle voor de esc bool voor het pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggler();
        }

        // zet main menu aan en uit
        if (esc == true)
        {
            Op.SetActive(true);
            Time.timeScale = 0.0f;
        }
        else { Op.SetActive(false); Time.timeScale = 1.0f; }


        // speedH is horizontal en speedV is vertical
        float horizon = Input.GetAxisRaw("Horizontal");
        float vertica = Input.GetAxisRaw("Vertical");

        // horizon is de horizontale input en vertica de verticale
        switch (horizon)
        {
            case 1:
                rb.AddForce(Vector3.right * speedH * Time.deltaTime, ForceMode.Impulse);
                break;
            case -1:
                rb.AddForce(Vector3.left * speedH * Time.deltaTime, ForceMode.Impulse);
                break;
        }
        switch (vertica)
        {
            case -1:
                rb.AddForce(Vector3.back * speedV * Time.deltaTime, ForceMode.Impulse);
                break;
            case 1:
                rb.AddForce(Vector3.forward * speedV * Time.deltaTime, ForceMode.Impulse);
                break;
        }
        // als je een kant op gaat en dan van directie verandert wordt je momentum stil gezet 
        // voordat je wisselt van kant
        if (horizon <= vertica && inputDetector == true)
        {
            rb.velocity = Vector3.zero;
        }
        if (horizon >= vertica && inputDetector == true)
        {
            rb.velocity = Vector3.zero;
        }


        // als de er geen input is wordt de camera langzaam stil gezet

        //checkt voor input en geeft een bool
        if (vertica != 0 || horizon != 0)
        {
            inputDetector = true;
        }
        else { inputDetector = false; }


        if (inputDetector == false)
        {
            rb.velocity = rb.velocity / Instellingen.cameraSmoothness;
        }
    }

    public void Toggler()
    {
        esc = !esc;
    }

    public void Play()
    {
        SceneManager.LoadScene("MaxScene");
        Debug.Log(" " + Instellingen.cameraSmoothness);
        // Instellingen.slider.value = Instellingen.cameraSmoothness;
        Instellingen.LoadSettings();

        
    }
    public void yalP()
    {
        SceneManager.LoadScene("Menu");
        Instellingen.LoadSettings();
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
   
}