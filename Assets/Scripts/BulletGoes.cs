using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGoes : MonoBehaviour
{

    public Vector3 position;

   
    public float speed = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        // Move our position a step closer to the target.
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, position, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, position) < 0.001f)
        {
            // Swap the position of the cylinder.
          
            Destroy(gameObject);
        }
    }
}
