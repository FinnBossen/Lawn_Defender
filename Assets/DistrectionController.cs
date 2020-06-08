using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistrectionController : MonoBehaviour
{

    public string TargetTag = "enemy";
    public int Distrectioncount;
    public float timeLeft = 6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
     
        if (Distrectioncount <= 0)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                Destroy(gameObject);
            }
          
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == TargetTag && Distrectioncount > 0 )
        {
            Distrectioncount--;

            if(other.gameObject.transform.GetChild(2).gameObject.name == "Throwing")
            {
                other.gameObject.transform.GetChild(2).gameObject.SetActive(false);
            }
            other.gameObject.GetComponent<VoxelAnimation>().enabled = true;
            other.gameObject.GetComponent<VoxelAnimation>().animActivated = true;
            other.gameObject.GetComponent<enemy>().isBottleThrower = false;
            other.gameObject.GetComponent<enemy>().Moves = true;
            other.gameObject.GetComponent<enemy>().target = gameObject;
         other.gameObject.GetComponent<enemy>().position = gameObject.transform.position;
            other.transform.gameObject.tag = "saved";


        

        }
        
    }



}
