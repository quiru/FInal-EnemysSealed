using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Malo2 : CompHerencia //comportamiento del malo2
{
    public DatosMalo2 utilMal2; //variable de datos del malo
    public float restaVida = hps; //asigna hps de compHerencia a restavida

    void Awake()
    {
        utilMal2.colorMalo = Color.red;
        restaVida = 100; // da puntos de vida a restavida

    }

    void Start()
    {
        StartCoroutine("CambioEstado"); //llama la corrutina que cambia los estados
    }

    Vector3 direction; //para asignar direccion
    void Update()
    {
        if (Generador.isPlaying == true) //si esta en true el juego sigue
        {
            float minDistance = 5;// para guardar el malo mas cercano
            GameObject ciudMasCecano = null; //para guardar el ciud mas cercano
            GameObject objHero = null; //para guardar el heroe

            foreach (var ciud in FindObjectsOfType<Ciudadano>()) //para encontrar el ciudadano mas cercano
            {
                Vector3 direccion = ciud.transform.position - transform.position; 

                if (direccion.magnitude <= minDistance)
                {
                    minDistance = direccion.magnitude;
                    ciudMasCecano = ciud.gameObject;
                }
            }

            objHero = GameObject.Find("hero(Clone)"); //guarda el objeto heroe

            if (ciudMasCecano != null)// si el ciudadanomascercano no es nulo entonces lo persigue
            {
                direction = Vector3.Normalize(ciudMasCecano.transform.position - transform.position);
                transform.position += direction * (2f / Random.Range(15, 71));
            }
            else if ((objHero.transform.position - transform.position).magnitude <= 5) //si entonces verifica si el heroe esta cerca y empiesa a rotar
            {
                transform.eulerAngles += new Vector3(0, 20, 0);
            }
            else
            {
                movimiento(); //si no continua con su movimiento
            }


        }
    }

    public struct DatosMalo2 //estructura de datos del malo2
    {
        public Color colorMalo;
    }
}
