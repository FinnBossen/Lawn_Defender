using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{

    public GameObject GameManager;
    private GameManager gameManager;
    public GameObject[] enemies;
    public Vector3 spawnValues;
    public float spawnWait = 2;
    public float spawnMostWait;
    public float spawnLeastWeit;
    public int startWait;
    public bool stop;
    public GameObject target;

    

    public int SpawnedEnemys;

  
    int randEnemy;
    private void Start()
    {
        gameManager = GameManager.GetComponent<GameManager>();
    }
   

    private void Update()
    {
        



        spawnWait -= Time.deltaTime;



        if (spawnWait < 0 && !stop)
        {
            randEnemy = Random.Range(0, enemies.Length );

            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), Random.Range(-spawnValues.z, spawnValues.z));
            GameObject go = Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            go.GetComponent<enemy>().target = target;
            go.GetComponent<enemy>().position = target.transform.position;
            gameManager.Currentenemys.Add(go);


            gameManager.spawnedEnemys++;
            spawnWait = Random.Range(spawnLeastWeit, spawnMostWait);
        }
    }

     

 
}
