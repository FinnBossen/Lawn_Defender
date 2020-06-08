using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private float timeLeft = -0.2f;
    public float coolDown = 2f;
    private VoxelAnimation VoxelAnimation1;
    public GameObject VoxelAnimation2;
    private VoxelAnimation voxelAnimation2;
    public GameObject[] Bottles;
    public GameObject target;
    public Vector3 position;
    public bool Moves = true;
    private LineRenderer laserLine;
    public float throwDistance = 8f;
    public bool isBottleThrower;
    public float speed = 10f;
    private GameObject randomBottle;
    public float ThrowingForce = 1000;
    private voxelloop Voxelloop;
    private bool insideDamageZone;

    private GameObject House;
    private HouseManager housemanager;
    public GameManager gameManager;


    public float EnemyDamage =1;
    public float EnemyLive = 1;
    // Start is called before the first frame update
    void Start()
    {


        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (VoxelAnimation2 != null)
        {
            if(VoxelAnimation2.GetComponent<VoxelAnimation>() != null) { 
             
            voxelAnimation2 = VoxelAnimation2.GetComponent<VoxelAnimation>();
            }
            else {
                Voxelloop = VoxelAnimation2.GetComponent<voxelloop>();
            }
            
        }
        VoxelAnimation1 = gameObject.GetComponent<VoxelAnimation>();
        House = GameObject.Find("Garden/Home");
        housemanager = House.GetComponent<HouseManager>();
        
        position = target.transform.position;
        laserLine = gameObject.GetComponent<LineRenderer>();
        laserLine.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        // Move our position a step closer to the target.
        if(EnemyLive <= 0)
        {
            gameManager.AddPosition(gameObject.transform.position);


            Destroy(gameObject);
        }

        if (isBottleThrower)
        {
            LayerMask layer = ~7;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, throwDistance, layer))
            {
                timeLeft -= Time.deltaTime;
                laserLine.enabled = true;
                laserLine.SetPosition(0, gameObject.transform.position);
                laserLine.SetPosition(1, hit.point);

                Moves = false;
                VoxelAnimation1.animActivated = false;



                if (timeLeft < 0)
                {
                    Voxelloop.enabled = true;
                    Voxelloop.animActivated = true;
                    timeLeft = coolDown;
                    Debug.Log("I am Throwing");
                    randomBottle = Bottles[Random.Range(0, Bottles.Length)];
                    GameObject go = Instantiate(randomBottle, new Vector3(transform.position.x , transform.position.y + 2.5f, transform.position.z), Quaternion.identity);
                    go.GetComponent<Rigidbody>().AddForce(transform.forward * ThrowingForce);
                }
                if (Voxelloop.animActivated == false)
                {
                    Voxelloop.enabled = false;
                }


            }


        }
        if (Moves) {
        
          
            float step = speed * Time.deltaTime; // calculate distance to move
                transform.position = Vector3.MoveTowards(transform.position, position, step);

                Quaternion targetRotation = Quaternion.LookRotation(DirectionXZ());
                gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation,
                targetRotation, 100 * Time.deltaTime);

                // Check if the position of the cube and sphere are approximately equal.
                if (Vector3.Distance(transform.position, position) < 0.001f)
                {
                    // Swap the position of the cylinder.
                    Destroy(gameObject);
                }

        }
    

        if (insideDamageZone)
        {
          
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
               
                timeLeft = coolDown;
                housemanager.losesLive(EnemyDamage);


            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            EnemyLive--;

            Destroy(other.gameObject);
          
        }

        if (other.tag == "DamageZone")
        {
            Moves = false;
            VoxelAnimation1.animActivated = false;
            if (VoxelAnimation2 != null)
            {
                voxelAnimation2.animActivated = true;
            }

            insideDamageZone = true;
            Debug.Log("is Pissing");
        }
    }

    Vector3 DirectionXZ()
    {
        Vector3 direction = target.transform.position - gameObject.transform.position;

        return direction;
    }


  
}
