using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuildDistrections : BuildSpotGeneral
{


    public GameObject[] Distrections;

   public GameObject Build;
    private Button Button;
    private GameObject randomDistrection;
    public bool PlayerInside = false;

    public static bool HasSomething;
    public int SomethingNumber;

    int buildState;


    // Start is called before the first frame update
    void Start()
    {

        Button = Build.GetComponent<Button>();
        Build.SetActive(false);
        Button.onClick.AddListener(TaskOnClick2);
 

    }

    private void Awake()
    {
    

    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            Buildsomething(0);
        }else if (Input.GetKeyDown("2"))
        {
            Buildsomething(1);
        }




    }
    void TaskOnClick2()
    {

        Buildsomething(0);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerInside = true;
            Build.SetActive(true);
        }
    }

    private void Buildsomething(int thing,bool ignoreInside=false)
    {
        
        randomDistrection = Distrections[thing];
 
        if ( PlayerInside || ignoreInside)
        {
            buildState = thing+1;


            if (this.gameObject.transform.childCount > 0)
            {
                Destroy(this.gameObject.transform.GetChild(0).gameObject);
                
              
            }
            GameObject go = Instantiate(randomDistrection, transform.position, transform.rotation);
           
            go.transform.parent = gameObject.transform;

       

        }
     
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerInside = false;
            Build.SetActive(false);
        }
    }

    public override int WriteState()
    {
        return buildState;
    }

    public override void ReadState(int bState)
    {
        Debug.LogWarning("Building with "+bState);

        buildState = bState;
        switch (buildState)
        {
            case 1:
                Buildsomething(0,true);
                break;
              
            case 2:
                Buildsomething(1,true);
                break;
            
              

        }
    }
}
