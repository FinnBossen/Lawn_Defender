using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TowerandPlantsManager : MonoBehaviour
{



  
    public GameObject[] Plants;
    private GameObject[] allBuildPoints;
    private GameObject randomPlant;
    private GameObject GameManager;
    public static bool firstload = true;
    public static bool destroyGameManager = false;
    
    // Start is called before the first frame update
    void Start()
    {

        if (SceneManager.GetActiveScene().buildIndex == 0)
            {
            for (int i = 0; i < allBuildPoints.Length; i++)
            {
                allBuildPoints[i].GetComponent<MeshRenderer>().enabled = false;
                allBuildPoints[i].GetComponent<buildSpot>().enabled = false;
            }
            }


        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            for (int i = 0; i < allBuildPoints.Length; i++)
            {
                allBuildPoints[i].GetComponent<MeshRenderer>().enabled =false;
                allBuildPoints[i].GetComponent<buildSpot>().enabled = true;
            }
        }

        GameManager = GameObject.Find("GameManager");



    }
    private void FixedUpdate()
    {
   
        
    }

    private void Awake()
    {
        

        int count = 0;
        foreach (Transform i in gameObject.transform)
        {
            count++;
        }
        allBuildPoints = new GameObject[count];
        count = 0;
        foreach (Transform i in gameObject.transform)
        {
            allBuildPoints[count] = i.gameObject;
            count++;
        }


        if (firstload)
        {
            firstload = false;
            for (int i = 0; i < allBuildPoints.Length; i++)
            {
                Debug.Log("Hallo");
                allBuildPoints[i].GetComponent<buildSpot>().Buildsomething();

            }

        }
    }

    public void DestroyGameManager()
    {
       
        Destroy(GameManager);
        Time.timeScale = 1;
        destroyGameManager = false;
        firstload = true;
    
        SceneManager.LoadScene(0, LoadSceneMode.Single);
     
    }




    // Update is called once per frame
    void Update()
    {
        if (destroyGameManager)
        {
            Debug.Log("Hallo");
            DestroyGameManager();
        }
    }
}
