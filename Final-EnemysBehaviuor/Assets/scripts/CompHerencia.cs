using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompHerencia : MonoBehaviour //comportamiento que heredan los enemigos
{
    States estados;
    int cambiaRot;
    int cambiaMov;
    float velRandom;
    public  static float hps;

    void Awake()
    {
        cambiaMov = Random.Range(0, 4); //inicia variable
        
        cambiaRot = Random.Range(0, 3);
    }

    void Start()
    {
        int daEstado = Random.Range(1, 4);
        estados = (States)daEstado; //da un estado
    }
    

    public void movimiento() //funcion para el movimiento aleatorio
    {
        velRandom = Random.Range(1f, 2f);
        switch (estados)
        {
            case States.rotating: //si el estado es rotating 
                if (cambiaRot == 0) // cambia de lado la rotacion
                {
                    transform.eulerAngles += new Vector3(0, 0.5f, 0);
                }
                else
                {
                    transform.eulerAngles -= new Vector3(0, 0.5f, 0);
                }
                break;
            case States.moving: //si el estado es moving
                if (cambiaMov == 0) //cambia la direccion del movimiento segun cambiamov
                {
                    transform.position += new Vector3(0, 0, velRandom * Time.deltaTime);
                }
                else if (cambiaMov == 1)
                {
                    transform.position -= new Vector3(0, 0, velRandom * Time.deltaTime);
                }
                else if (cambiaMov == 2)
                {
                    transform.position -= new Vector3(velRandom * Time.deltaTime, 0, 0);
                }
                else if (cambiaMov == 3)
                {
                    transform.position += new Vector3(velRandom * Time.deltaTime, 0, 0);
                }
                break;
            case States.idle: //si el estado es idle se queda quieto
                transform.position += new Vector3(0, 0, 0);
                break;
        }
    }

    IEnumerator CambioEstado() //corrutina para hacer cambiar el estado y las variables cambiamov y cambiarot
    {
        while (true)
        {
            if (estados == (States)0)
            {
                estados = (States)1;
                cambiaMov = Random.Range(0, 4);
            }
            else if (estados == (States)1)
            {
                estados = (States)2;
            }
            else
            {
                estados = (States)0;
                cambiaRot = Random.Range(0, 2);
            }


            yield return new WaitForSeconds(3);
        }
    }
}

public enum States //enum de estados
{
    rotating, moving, idle 
}
