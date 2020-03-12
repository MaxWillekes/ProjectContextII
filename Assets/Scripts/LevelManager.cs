using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Player player;
    public UserInterfaceManager ui;
    public static LevelManager Instance { get; private set; }

    public GameObject Egg1;
    public GameObject Egg2;

    public float HungerRemaining = 100;
    public float ThirstRemaining = 100;

    public int day = 0;

    [SerializeField]
    private Light mainLight;

    [SerializeField]
    private Color newLampColor;

    [SerializeField]
    private GameObject ClosedDome;

    [SerializeField]
    private GameObject OpenDome;

    [SerializeField]
    private DayTrigger dayTrigger;

    void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
        player = FindObjectOfType<Player>();
        ui = FindObjectOfType<UserInterfaceManager>();
    }

    public void ChangeLighting() =>
        mainLight.color = newLampColor;

    public void ChangeDome() =>
        dayTrigger.gameObject.SetActive(true);

    public void NewDay()
    {
        day++;

        StartCoroutine(ui.SetNightImage());
        if (day == 1)
        {
            Egg1.SetActive(true);
            Egg2.SetActive(true);
        }
        else
        {
            Egg1.SetActive(false);
            Egg2.SetActive(false);
        }

        if (day == 3)
        {
            ChangeDome();
        }

        ui.taskSet1Progression = 0;
    }

    public void RemoveThirst()
    {
        ThirstRemaining += 50;
    }

    public void RemoveHunger()
    {
        HungerRemaining += 35;
    }

    public void Update()
    { 
        if( HungerRemaining >= 100)
        {
            HungerRemaining = 100;
        }

        if (ThirstRemaining >= 100)
        {
            ThirstRemaining = 100;
        }

        HungerRemaining -= 0.005f;
        ThirstRemaining -= 0.00885f;

        if(HungerRemaining <= 0 || ThirstRemaining <= 0)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("GameOver");
        }
    }
}
