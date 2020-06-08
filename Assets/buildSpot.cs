using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class buildSpot : BuildSpotGeneral
{
    public GameObject[] Plants;
    public GameObject Turret;
    public GameObject Build;
    public Button Button;
    private GameObject randomPlant;
    public bool PlayerInside = false;
    int buildState;
    // Start is called before the first frame update
    void Start()
    {
        Button = Build.GetComponent<Button>();

        Build.SetActive(false);
        Button.onClick.AddListener(TaskOnClick);

    }

    private void Awake()
    {

     
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TaskOnClick()
    {

        
    }

        private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerInside = true;
            if (Input.GetKeyDown("1"))
            {
                ChangeSomething();
            }

        }
    }

    public void Buildsomething()
    {
    


        switch (Random.Range(1, 7))
        {
            case 1:
                BuildPlant1();
                break;

            case 2:
                BuildPlant2();
                break;


            case 3:
                BuildPlant3();
                break;

            case 4:
                BuildPlant4();
                break;

            case 5:
                BuildPlant5();
                break;
            case 6:
                BuildPlant6();
                break;
            case 7:
                BuildTurret1();
                break;


        }

   


      
        


    }

    public void ChangeSomething()
    {

        if (this.gameObject.transform.GetChild(0).CompareTag("Plant") && this.gameObject.GetComponent<buildSpot>().PlayerInside)
        {
            Destroy(this.gameObject.transform.GetChild(0).gameObject);
            BuildTurret1();
           
        
    }
        else if (this.gameObject.transform.GetChild(0).CompareTag("Turret") && this.gameObject.GetComponent<buildSpot>().PlayerInside)
        {
            Destroy(this.gameObject.transform.GetChild(0).gameObject);
            switch (Random.Range(1, 6))
            {
                case 1:
                    BuildPlant1();
                    break;

                case 2:
                    BuildPlant2();
                    break;


                case 3:
                    BuildPlant3();
                    break;

                case 4:
                    BuildPlant4();
                    break;

                case 5:
                    BuildPlant5();
                    break;
                case 6:
                    BuildPlant6();
                    break;
            }
        };

    }


    public void BuildPlant1()
    {
        buildState = 3;
       
        GameObject go = Instantiate(Plants[0], transform.position, Quaternion.identity);
        go.transform.parent = gameObject.transform;

    }

    public void BuildPlant2()
    {
        buildState = 4;

        GameObject go = Instantiate(Plants[1], transform.position, Quaternion.identity);
        go.transform.parent = gameObject.transform;

    }

    public void BuildPlant3()
    {
        buildState = 5;
     
        GameObject go = Instantiate(Plants[2], transform.position, Quaternion.identity);
        go.transform.parent = gameObject.transform;

    }

    public void BuildPlant4()
    {
        buildState = 6;
    
        GameObject go = Instantiate(Plants[3], transform.position, Quaternion.identity);
        go.transform.parent = gameObject.transform;

    }

    public void BuildPlant5()
    {
        buildState = 7;
    
        GameObject go = Instantiate(Plants[4], transform.position, Quaternion.identity);
        go.transform.parent = gameObject.transform;

    }

    public void BuildPlant6()
    {
        buildState = 8;
      ;
        GameObject go = Instantiate(Plants[5], transform.position, Quaternion.identity);
        go.transform.parent = gameObject.transform;

    }

    public void BuildTurret1()
    {
        buildState = 9;

        GameObject go = Instantiate(Turret, transform.position, Quaternion.identity);
        go.transform.parent = gameObject.transform;
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
        Debug.LogWarning("Building with " + bState);

        buildState = bState;
        switch (buildState)
        {
            case 3:
                BuildPlant1();
                break;

            case 4:
                BuildPlant2();
                break;


            case 5:
                BuildPlant3();
                break;

            case 6:
                BuildPlant4();
                break;

            case 7:
                BuildPlant5();
                break;
            case 8:
                BuildPlant6();
                break;
            case 9:
                BuildTurret1();
                break;


        }
    }

}
