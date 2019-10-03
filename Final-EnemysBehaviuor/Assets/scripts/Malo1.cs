using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class Malo1 : CompHerencia //comportamiento del malo1
{
    //EL COMPORTAMIENTO ESTA COMENTADO EN SCRIPT Malo2, PUES SON MUY SIMILARES
    public DatosMalo1 utilMal1;
    public float restaVida = hps;

    void Awake()
    {
        utilMal1.colorMalo = Color.green;
        restaVida = 100;
        
    }

    void Start()
    {
        StartCoroutine("CambioEstado");
    }

    Vector3 direction;
    void Update()
    {
        if (Generador.isPlaying == true)
        {
            float minDistance = 5;
            GameObject ciudMasCecano = null;
            GameObject objHero = null;

            foreach (var ciud in FindObjectsOfType<Ciudadano>())
            {
                Vector3 direccion = ciud.transform.position - transform.position;

                if (direccion.magnitude <= minDistance)
                {
                    minDistance = direccion.magnitude;
                    ciudMasCecano = ciud.gameObject;
                }
            }

            objHero = GameObject.Find("hero(Clone)");

            if (ciudMasCecano != null)
            {
                direction = Vector3.Normalize(ciudMasCecano.transform.position - transform.position);
                transform.position += direction * (2f / Random.Range(15, 71));
            }
            else if ((objHero.transform.position - transform.position).magnitude <= 5) //si el heroe esta cerca lo empiesa a perseguir
            {
                direction = Vector3.Normalize(objHero.transform.position - transform.position);
                transform.position += direction * (2f / Random.Range(15, 71));
            }
            else
            {
                movimiento();
            }


        }
    }

    public struct DatosMalo1
    {
        public Color colorMalo;
    }
}
