using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : MonoBehaviour
{

    public List<GameObject> enemysTriggered = new List<GameObject>();
    public float weaponRange;

    private LineRenderer laserLine;

   


    public GameObject Bullet;

    private float timeLeft;
    public float coolDown = 0.2f;
    public float speed =20;

    bool firstEnemy =false;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = coolDown;
        laserLine = gameObject.GetComponent<LineRenderer>();
        laserLine.enabled = false;
      
      
    
    
    }

    // Update is called once per frame
    void Update()

    {
  

        if (firstEnemy) { 
        if (enemysTriggered[0] != null )
            {
                if (!enemysTriggered[0].CompareTag("saved")){
                laserLine.enabled = true;

                LayerMask layer = ~0;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, weaponRange, layer, QueryTriggerInteraction.Ignore))
            {
                laserLine.SetPosition(0, gameObject.transform.position);
                laserLine.SetPosition(1, hit.point);

                // wenn der Raycast den Spieler trifft wird die Aimtime runtergezählt
                if (hit.transform.tag == "enemy")
                {
                        
                        timeLeft -= Time.deltaTime;

                        if (timeLeft < 0)
                        {
                            timeLeft = coolDown;

                            GameObject go = Instantiate(Bullet, transform.position, Quaternion.identity);
                            go.GetComponent<BulletGoes>().position = hit.transform.position;
                            go.GetComponent<BulletGoes>().speed = speed;
                        }



                    }
             
            }
            Quaternion targetRotation = Quaternion.LookRotation(DirectionXZ());
            gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation,
            targetRotation, 45 * Time.deltaTime);

                }
                else
                {
                    enemysTriggered.RemoveAt(0);
                }

            }
        else
        {
            enemysTriggered.RemoveAt(0);
                Debug.Log(enemysTriggered);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "enemy" || other.tag == "bottleEnemy" || other.tag == "pissEnemy") {
          
        enemysTriggered.Add(other.gameObject);
            firstEnemy = true;

            Debug.Log (enemysTriggered);
        }
    }



    Vector3 DirectionXZ()
    {
        Vector3 direction = enemysTriggered[0].transform.position - gameObject.transform.position;

        return direction;
    }
}
