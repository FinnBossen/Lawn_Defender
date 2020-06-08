using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildState : MonoBehaviour
{

    int[] buildState;

    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Start is called before the first frame update
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        BuildStateLoad();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Save content of spot as an int at level end
    /// </summary>
    public void BuildStateSave()
    {

        BuildSpotGeneral[] bsg = GameObject.FindObjectsOfType<BuildSpotGeneral>();
        
        buildState = new int[bsg.Length];
        for(int n=0; n<buildState.Length;n++)
        {


            var b = bsg[n];
            buildState[n]=b.WriteState();
            Debug.Log("Write: " + buildState[n]);
        }

    }

    /// <summary>
    /// Construct saved contents from int at levelstart.
    /// </summary>
    void BuildStateLoad()
    {
        Debug.LogWarning("GO");
        BuildSpotGeneral[] bsg = FindObjectsOfType<BuildSpotGeneral>();
        Debug.LogWarning("Found "+bsg.Length+" Build Spot Generals");
        if (buildState != null)
        {
            for (int n = 0; n < bsg.Length; n++)
            {  
                var b = bsg[n];
               b.ReadState(buildState[n]);
                Debug.Log("Read: " + buildState[n]);
            }
        }
        

    }

}
