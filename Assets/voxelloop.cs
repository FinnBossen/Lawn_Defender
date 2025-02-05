﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class voxelloop : MonoBehaviour
{
    public GameObject[] myself;
    public GameObject[] otherStuff;
    public GameObject[] otherAnimationFragments;
    public bool animActivated;
    public GameObject[] frames = new GameObject[2];
    private float animationSpeed;

    public float Speed = 0.1f;
    public bool onlyOnce;

    private bool firstNonAnim = true;
    private bool firstFrame = true;
    public bool holdLastFrame = false;

    private int arrayPos = 0;

    void Start()
    {
      
        animationSpeed = Speed;

    }


    void FixedUpdate()
    {
        if (animActivated)
        {

            for (int i = 0; i < myself.Length ; i++)
            {
               myself[i].SetActive(true);
            }

            for (int i = 0; i < otherAnimationFragments.Length ; i++)
            {
                otherAnimationFragments[i].SetActive(false);
            }
            animationSpeed -= Time.deltaTime;
            for (int i = 0; i < otherStuff.Length; i++)
            {
              
                otherStuff[i].SetActive(false);
               
            }
            if (firstFrame)
            {

                UpdateMesh();
                firstFrame = false;
            }
            if (animationSpeed < 0)
            {

                UpdateMesh();

                animationSpeed = Speed;
            }
        }
        else
        {

            if (!holdLastFrame) { 
            for (int i = 0; i < frames.Length; i++)
            {
                frames[i].SetActive(false);
            }
            }




        }

  

    }

    void UpdateMesh()
    {



        if (arrayPos >= frames.Length - 1)
        {
           
            frames[arrayPos].SetActive(false);
            arrayPos = 0;
          
            if (onlyOnce)
                {
                    animActivated = false;
                    firstFrame = true;

               



              


            }

        }
        else
        {
            frames[arrayPos].SetActive(false);
            arrayPos += 1;
        }

        if (holdLastFrame && animActivated == false)
        {

            for (int i = 0; i < frames.Length; i++)
            {
                frames[i].SetActive(false);
            }

            frames[frames.Length-1].SetActive(true);
        }
        else
        {
            frames[arrayPos].SetActive(true);
        }

    }
}