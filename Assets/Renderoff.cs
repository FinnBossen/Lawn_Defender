using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Renderoff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int children = transform.childCount;

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            for (int i = 0; i < children; ++i)
            {
                transform.GetChild(i).gameObject.SetActive(false);

            }
        }



        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            for (int i = 0; i < children; ++i)
            {
                transform.GetChild(i).gameObject.SetActive(true);

            }
        }

    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
