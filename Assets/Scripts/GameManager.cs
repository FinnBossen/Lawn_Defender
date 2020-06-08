using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;

    private GameManager()
    {
    }

    public static GameManager Instance
    {
        get { return _instance; }
    }

  
  
    public static  List<Vector3> EnemyDeathPositions = new List<Vector3>();
    public int MaxEnemys;
    public List<GameObject> Currentenemys;
    public int spawnedEnemys = 0;
    public GameObject Spawn1;
    public GameObject Spawn2;
    public GameObject Spawn3;
    public GameObject Spawn4;
    public Button NextScene;
    public EnemySpawner spawn1;
    public EnemySpawner spawn2;
    public EnemySpawner spawn3;
    public EnemySpawner spawn4;
    public GameObject Pfandflasche;
    public  static int PfandCoins = 0;
    public Text CurrentWave;
    public GameObject YouWon ;
    public GameObject Player;
    public Text PfandFlaschenText;
    public BuildState buildState;
    public GameObject instruction;

    private float timeLeft =10;

    private void Awake()
    {
        Object.FindObjectsOfType<GameManager>();
        
    
    }
    // Start is called before the first frame update
    void Start()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(gameObject);
        timeLeft = 10;
        NextScene.onClick.AddListener(TaskOnClick);
     
        spawn1 = Spawn1.GetComponent<EnemySpawner>();
        spawn2 = Spawn2.GetComponent<EnemySpawner>();
        spawn3 = Spawn3.GetComponent<EnemySpawner>();
        spawn4 = Spawn4.GetComponent<EnemySpawner>();

        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            for (var i = 0; i < EnemyDeathPositions.Count; i++)
            {
                Debug.Log("Halli");
                GameObject go = Instantiate(Pfandflasche, EnemyDeathPositions[i], Quaternion.identity);
                instruction.SetActive(true);

                
            }
        }
    }


    void OnLevelWasLoaded()
    {
       
        timeLeft = 10;
        NextScene.onClick.AddListener(TaskOnClick);

        spawn1 = Spawn1.GetComponent<EnemySpawner>();
        spawn2 = Spawn2.GetComponent<EnemySpawner>();
        spawn3 = Spawn3.GetComponent<EnemySpawner>();
        spawn4 = Spawn4.GetComponent<EnemySpawner>();
        Debug.Log("Halllo new Szene Maxenemies = "+ MaxEnemys);

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            for (var i = 0; i < EnemyDeathPositions.Count; i++)
            {
               
                GameObject go = Instantiate(Pfandflasche, EnemyDeathPositions[i], Quaternion.identity);
                Debug.Log(EnemyDeathPositions[i]);


            }
            instruction.SetActive(true);
            spawn1.stop = true;
            spawn2.stop = true;
            spawn3.stop = true;
            spawn4.stop = true;
        }

       

    }
    // Update is called once per frame
    void Update()
    {

        timeLeft -= Time.deltaTime;
     
        for (var i = 0; i < Currentenemys.Count; i++)
        {
            if (Currentenemys[i] == null)
            {
                Currentenemys.RemoveAt(i);
            }

        }
        Debug.Log(spawnedEnemys+":" +MaxEnemys);

            PfandFlaschenText.text = "returnable bottle: " + PfandCoins.ToString();
        CurrentWave.text = "Enemys This Wave: " + Currentenemys.Count.ToString();

        if (spawnedEnemys >= MaxEnemys )
        {
 
            spawn1.stop = true;
            spawn2.stop = true;
            spawn3.stop = true;
            spawn4.stop = true;
        }


        if(timeLeft <= 0 && SceneManager.GetActiveScene().buildIndex == 0) {
        if (Currentenemys.Count == 0)
        {
                timeLeft = 20;
            YouWon.SetActive(true);
                
        }
        }


        if (SceneManager.GetActiveScene().buildIndex == 1 && Input.GetKeyDown(KeyCode.Return))
        {
            
                YouWon.SetActive(true);
               
            
        }


    }

    public void AddPosition(Vector3 vector3)
    {
      
       

        EnemyDeathPositions.Add(vector3);
    }


    void TaskOnClick()
    {
        spawnedEnemys = 0;
        spawn1.stop = false;
        spawn2.stop = false;
        spawn3.stop = false;
        spawn4.stop = false;
        buildState.BuildStateSave();
        
        MaxEnemys = MaxEnemys + 10;
        if (SceneManager.GetActiveScene().buildIndex == 0) {
        SceneManager.LoadScene(1);
        }
        else { 

         if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                instruction.SetActive(false);
                SceneManager.LoadScene(0);
        }
        }
        YouWon.SetActive(false);
     

    }
}
