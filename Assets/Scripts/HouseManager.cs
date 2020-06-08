using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HouseManager : MonoBehaviour
{
    public GameObject GameManager;
    public GameObject AllPlants;
    private GameObject[] Plants;
    public float HouseLivePoints = 0;
    public float CurrentLives;
    public Text LifeText;
    public GameObject youLose;
    public Image HealthGui;
    public Button retry;
    private float timeLeft = 10f;
    // Start is called before the first frame update


    void OnEnable()
    {
       
        SceneManager.sceneLoaded += OnSceneLoaded;
     
       
    }

    private void Start()
    {

        if (youLose != null)
        {
            youLose.SetActive(false);
        }
        Time.timeScale = 1;
        retry.onClick.AddListener(TaskOnClick);
        HouseLivePoints = 0;
        AllPlants = GameObject.Find("BuildPointsPlantsandTurrets");
        Plants = new GameObject[AllPlants.transform.childCount];
        for (int i = 0; i < AllPlants.transform.childCount; i++)
        {
            Plants[i] = AllPlants.transform.GetChild(i).gameObject;
            if (Plants[i].gameObject.transform.GetChild(0).CompareTag("Plant"))
            {
                Debug.Log("Hallo");
                HouseLivePoints = HouseLivePoints + 10;
            }
        }
        CurrentLives = HouseLivePoints;


        UpdateView();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            if (CurrentLives <= 0)
            {


                Debug.Log("you Lose");
                youLose.SetActive(true);
                Time.timeScale = 0;
            }
        }
            LifeText.text = "Count: " + CurrentLives.ToString();
   
     


        
    }


    public void losesLive(float damage)
    {
        CurrentLives = CurrentLives - damage;
        UpdateView();
    }
    void UpdateView()
    {
        HealthGui.fillAmount = CurrentLives/ HouseLivePoints;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(youLose != null) {
        youLose.SetActive(false);
            }
        Time.timeScale = 1;
        retry.onClick.AddListener(TaskOnClick);
        HouseLivePoints = 0;
        AllPlants = GameObject.Find("BuildPointsPlantsandTurrets");
        Plants = new GameObject[AllPlants.transform.childCount];
        for (int i = 0; i < AllPlants.transform.childCount; i++)
        {
            Plants[i] = AllPlants.transform.GetChild(i).gameObject;
            if (Plants[i].gameObject.transform.GetChild(0).CompareTag("Plant"))
            {
                Debug.Log("Hallo");
                HouseLivePoints = HouseLivePoints + 10;
            }
        }
        CurrentLives = HouseLivePoints;
    

        UpdateView();
    }

    void TaskOnClick()
    {
       
        TowerandPlantsManager.firstload = true;
        youLose.SetActive(false);
        TowerandPlantsManager.destroyGameManager = true;



    }

    }
