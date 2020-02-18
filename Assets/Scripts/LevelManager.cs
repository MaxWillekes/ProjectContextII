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

    public int day = 0;

    [SerializeField]
    private Light mainLight;

    [SerializeField]
    private Color newLampColor;

    [SerializeField]
    private GameObject ClosedDome;

    [SerializeField]
    private GameObject OpenDome;

    void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
        player = FindObjectOfType<Player>();
        ui = FindObjectOfType<UserInterfaceManager>();
    }

    public void ChangeLighting()
    {
        mainLight.color = newLampColor;
    }

    public void ChangeDome()
    {
        OpenDome.SetActive(true);
        ClosedDome.SetActive(false);
    }

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
}
