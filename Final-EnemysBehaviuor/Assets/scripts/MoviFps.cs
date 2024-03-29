﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoviFps : MonoBehaviour
{
    float mouseX;
    //PersHero utilVel = new PersHero();
    float velRand;
    //GameObject velVel;

    void Awake()
    {
        velRand = Random.Range(2, 5);
    }

    void Update()
    {
        if (Generador.isPlaying == true)
        {
            mouseX += Input.GetAxis("Mouse X");
            transform.eulerAngles = new Vector3(0, mouseX, 0);
            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= transform.right * velRand * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += transform.right * velRand * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position -= transform.forward * velRand * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += transform.forward * velRand * Time.deltaTime;
            } 
        }
    }
}
