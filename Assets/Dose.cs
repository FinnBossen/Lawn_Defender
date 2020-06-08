using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dose : MonoBehaviour
{
    private GameObject House;
    private HouseManager housemanager;

    public float Damage = 3;
    // Start is called before the first frame update
    void Start()
    {
        House = GameObject.Find("Garden/Home");
        housemanager = House.GetComponent<HouseManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Garden/House"))
        {
            housemanager.losesLive(Damage);
        }
    }
}
