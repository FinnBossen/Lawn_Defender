using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mesrenderoff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
