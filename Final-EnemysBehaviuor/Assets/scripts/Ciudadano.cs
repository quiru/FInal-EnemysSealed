using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Ciudadano : MonoBehaviour
{
    public DatosCiud utilCiud; //variable de estructura

    void Awake()
    {
        utilCiud.edadCiudd = Random.Range(15, 80 ); //le da edad para moverse segun esta
        int darFrase = Random.Range(1, 9); //le da nombre para segun este dar mensaje
        utilCiud.varFrases = (DatosCiud.frasesCiudd)darFrase; //asigna el nombre a la variable
    }


    Vector3 direction; //para verificar la distancia
    void Update()
    {
        if (Generador.isPlaying == true) //si la variable es true esta en juego. controla el loop
        {
            float minDistance = 5; //base para la distancia
            GameObject maloMasCecano = null; // para guardar el malo mas cercano

            foreach (var malo in FindObjectsOfType<Malo1>()) //para encontrar el malo mas cercano
            {
                Vector3 direccion = malo.transform.position - transform.position; //para verificar la distancia

                if (direccion.magnitude <= minDistance)// verifica la distancia
                {
                    minDistance = direccion.magnitude; //asigna la distancia 
                    maloMasCecano = malo.gameObject; //asigna el mas cercano
                }
            }
            foreach (var malo in FindObjectsOfType<Malo2>())//comentado arriba para el malo1
            {
                Vector3 direccion = malo.transform.position - transform.position;

                if (direccion.magnitude <= minDistance)
                {
                    minDistance = direccion.magnitude;
                    maloMasCecano = malo.gameObject;
                }
            }

            if (maloMasCecano != null) //si si hay un malo cercano lo empiesa a perseguir
            {
                direction = Vector3.Normalize(maloMasCecano.transform.position - transform.position);
                transform.position -= direction * (2f / utilCiud.edadCiudd);
            }
            
        }
    }
    

    void OnCollisionEnter(Collision collision) //si choca con algun malo lo convierte en en ese tipo
    {
        if (collision.transform.name == "malo1")
        {
            this.gameObject.AddComponent<Malo1>();
            gameObject.GetComponent<Renderer>().material.color = collision.transform.GetComponent<Renderer>().material.color;
            transform.name = "malo1";
            Destroy(this.gameObject.GetComponent<Ciudadano>());
        }
        else if (collision.transform.name == "malo2")
        {
            this.gameObject.AddComponent<Malo2>();
            gameObject.GetComponent<Renderer>().material.color = collision.transform.GetComponent<Renderer>().material.color;
            transform.name = "malo2";
            Destroy(this.gameObject.GetComponent<Ciudadano>());
        }
    }

    public struct DatosCiud //estructura de datos del ciudadano
    {
        public enum frasesCiudd
        {
            rolando, josue, jaimito, romualdo, dioselina, maripan, consepcion, pancracia
        }
        public frasesCiudd varFrases;
        
        public int edadCiudd;
        
    }
}
