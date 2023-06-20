using System.Collections;
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
    public bool esc = true;
    GameObject Op;
    public static GameObject Ob;
    public static GameObject Zoom;
    Vector3 victor;
    bool spedUp = false;
    Image speedControlButton;
    Sprite Speed1;
    public Sprite Speed2;



    private void Awake()
    {
        Op = GameObject.Find("Main");
        rb = GetComponent<Rigidbody>();
        Ob = GameObject.Find("Options");
        Zoom = GameObject.Find("CameraController");
        speedControlButton = GameObject.Find("Speed").GetComponent<Image>();
        Speed1 = speedControlButton.sprite;
    }

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of scene.
        string sceneName = currentScene.name;

        // de menu objecten staan standaar aan en worden hier uitgezet zodat de de player prefs geladen worden
        if (sceneName != "Menu")
        {
            esc = false;
            Ob.SetActive(false);
            Op.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedV = 3000f;
            speedH = 3000f;
        }
        else
        {
            speedV = 1500f;
            speedH = 1500f;
        }

        // toggle voor de esc bool, voor het pause menu
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
        else if (esc == false) 
        { 
            Op.SetActive(false); 
            Time.timeScale = 1.0f;
            if (spedUp)
            {
                Time.timeScale = 2.0f;
                speedControlButton.sprite = Speed2;
            }
            else if (spedUp == false)
            {
                Time.timeScale = 1.0f;
                speedControlButton.sprite = Speed1;
            }
        }

        if (Ob.activeSelf == true && esc == true)
        { 
          Op.SetActive(false);
        }
       

        // speedH is horizontal en speedV is vertical
        float horizon = Input.GetAxisRaw("Horizontal");
        float vertica = Input.GetAxisRaw("Vertical");
        float scroll = Input.GetAxisRaw("Mouse ScrollWheel");


        // horizon is de horizontale input en vertica de verticale. Scroll is om uit te zoomen
        switch (scroll)
        {
            case -0.1f:
                Zoom.transform.position += victor = new Vector3(0, 1 * 2, 0);
                // rb.AddForce(Vector3.up * 1000);
                break;
            case 0.1f:
                // rb.AddForce(Vector3.down * 1000);
                Zoom.transform.position += victor = new Vector3(0, 1 * -2, 0);
                break;
        }
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

        //checkt voor input
        if (vertica != 0 || horizon != 0)
        {
            inputDetector = true;
        }
        else { inputDetector = false; }

        // laat de camera langzaam doorglijden als je de knoppen los laat
        if (inputDetector == false)
        {
            rb.velocity = rb.velocity / Instellingen.cameraSmoothness;
        }

    }

    public void Toggler()
    {
        esc = !esc;
    }

    //laad MaxScene
    // wordt later verandert naar een levelselector
    public void Play()
    {
        SceneManager.LoadScene("MaxScene");
        Instellingen.LoadSettings();

        
    }
    // gaat van de scene van nu naar het main menu
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
    public void ToggleTime()
    {
        spedUp = !spedUp;
    }


}