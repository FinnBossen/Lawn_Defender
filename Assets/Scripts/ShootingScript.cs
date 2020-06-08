using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public float rotateSpeed = 3f;
    public GameObject Bullet;
    private float timeLeft;
    public float coolDown = 30f;
    private LayerMask layer = ~0;
    private voxelloop Voxelloop;
    public GameObject ShootPoint;

    bool shoot = false;
    // Start is called before the first frame updateS
    void Start()
    {
        Voxelloop = GetComponent<voxelloop>();
        timeLeft = coolDown;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 100, layer, QueryTriggerInteraction.Ignore))
        {
            RotateToward(hit.point);

            if (Input.GetMouseButton(0))
            {
                

                if (timeLeft < 0)
                    {
                    Voxelloop.enabled = true;
                    Voxelloop.animActivated = true;
                    timeLeft = coolDown;
                        GameObject go = Instantiate(Bullet, ShootPoint.transform.position, Quaternion.identity);
                        go.GetComponent<BulletGoes>().position = hit.point;

                    }
                if (Voxelloop.animActivated == false)
                {
                    Voxelloop.enabled = false;
                }

            }
           
        }
      

    

    }

    public void RotateToward(Vector3 target)
    {

        Vector3 dontlookDown = new Vector3(target.x, 0, target.z);
        Vector3 dontlookDown2 = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z);
        Vector3 targetDir = dontlookDown - dontlookDown2;

        // The step size is equal to speed times frame time.
        float step = rotateSpeed * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(gameObject.transform.forward, targetDir, step, 0.0f);
        Debug.DrawRay(transform.position, newDir, Color.red);

        // Move our position a step closer to the target.
        gameObject.transform.rotation = Quaternion.LookRotation(newDir);
    }
}
