using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersHero : MonoBehaviour //Comportamiento de heroe
{
    GameObject buscaCanvas; //para cambiar los mensajes texto de la clase generador
    Ciudadano.DatosCiud utilCiu; //para utilizar los datos del ciudadano
    float heroHp; //puntos de vida de heroe
    int live; //vidas del heroe

    void Awake()
    {
        heroHp = 100; //asigna los p.v
        live = 3; //da 3 vidas
        buscaCanvas = GameObject.Find("GameObject"); //busca objeto que tiene el script del generador y el canvas
        StartCoroutine("ResetMens"); //llama corroutina para resetear el mensaje del ciudadano 
    }

    void Update()
    {
        buscaCanvas.GetComponent<Generador>().salud.text = "HP: " + heroHp + "\n LIVE: " + live; //mensaje para mostrar salud y vidas
    }

    void OnCollisionEnter(Collision colision)
    {
        if (colision.transform.name == "malo1") //si  colisiona con el malo 1
        {
            if (Input.GetKey(KeyCode.Space)) //y tambien debe presionar espacio para hacer daño
            {
                colision.gameObject.GetComponent<Malo1>().restaVida -= 15; // resta 15 de vida al malo 
                colision.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 3, ForceMode.Impulse); //es para empujar el malo
                if (colision.gameObject.GetComponent<Malo1>().restaVida <= 0) //verifica si la vida del malo llego a 0 y lo destruye
                {
                    Destroy(colision.gameObject); //destruye el objeto 
                }
            }
            else //si no presiona espacio el malo le hara daño
            {
                heroHp -= 10; //le hace daño al heroe
                if (heroHp <= 0) // si los p.v llegan a cero 
                {
                    live -= 1; //le resta 1 a las vidas 
                    heroHp = 100; //vuelve los P.v de nuevo a 100
                    if (live == 0) //si las vidas llegan a 0
                    {
                        Generador.isPlaying = false; //la variable general de juego se desactiva
                        buscaCanvas.GetComponent<Generador>().mensGamover.text = "GAME OVER \n perdiste"; //muestra un mensaje de game over
                    }
                }
            }

        }
        else if (colision.transform.name == "malo2") //comentado arriba para el malo1
        {
            if (Input.GetKey(KeyCode.Space))
            {
                colision.gameObject.GetComponent<Malo2>().restaVida -= 20; //a este le hacemos mas daño
                colision.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 3, ForceMode.Impulse);
                if (colision.gameObject.GetComponent<Malo2>().restaVida <= 0)
                {
                    Destroy(colision.gameObject);
                }
            }
            else
            {
                heroHp -= 25; //pero este tambien nos hace mas daño
                if (heroHp <= 0)
                {
                    live -= 1;
                    heroHp = 100;
                    if (live == 0)
                    {
                        Generador.isPlaying = false;
                        buscaCanvas.GetComponent<Generador>().mensGamover.text = "GAME OVER \n perdiste";
                    }
                }
            }
        }
        else if (colision.transform.name == "Ciudadanito") //si colisiona con un ciudadano, mostrara una frase segun su nombre
        {
            utilCiu = colision.gameObject.GetComponent<Ciudadano>().utilCiud;
            switch (utilCiu.varFrases)
            {
                case Ciudadano.DatosCiud.frasesCiudd.rolando:
                    buscaCanvas.GetComponent<Generador>().mensCiudadano.text = "hola manejate bien pa que te friten de ultimo";
                    break;
                case Ciudadano.DatosCiud.frasesCiudd.josue:
                    buscaCanvas.GetComponent<Generador>().mensCiudadano.text = "ojo que los verdes lo persiguen";
                    break;
                case Ciudadano.DatosCiud.frasesCiudd.jaimito:
                    buscaCanvas.GetComponent<Generador>().mensCiudadano.text = "los huevitos dan vueltas";
                    break;
                case Ciudadano.DatosCiud.frasesCiudd.romualdo:
                    buscaCanvas.GetComponent<Generador>().mensCiudadano.text = "con la tecla espacio les quira vida";
                    break;
                case Ciudadano.DatosCiud.frasesCiudd.dioselina:
                    buscaCanvas.GetComponent<Generador>().mensCiudadano.text = "solo tienes 3 vidas, aprovechalas";
                    break;
                case Ciudadano.DatosCiud.frasesCiudd.maripan:
                    buscaCanvas.GetComponent<Generador>().mensCiudadano.text = "no juegues con la comida";
                    break;
                case Ciudadano.DatosCiud.frasesCiudd.consepcion:
                    buscaCanvas.GetComponent<Generador>().mensCiudadano.text = "si se le aparece la virgen, hechele mano";
                    break;
                case Ciudadano.DatosCiud.frasesCiudd.pancracia:
                    buscaCanvas.GetComponent<Generador>().mensCiudadano.text = "si se comio un moco despues no se arrepienta";
                    break;
            }
        }
        else if (colision.transform.name == "items") //si colisiona con un item
        {
            colision.transform.SetParent(this.gameObject.transform); //lo vuelve hijo del heroe
            colision.gameObject.GetComponent<Renderer>().enabled = false; //insbilita el renderer
        }
    }

    IEnumerator ResetMens() //corrutina para resetear el mensaje del ciudadano
    {
        while (true)
        {
            buscaCanvas.GetComponent<Generador>().mensCiudadano.text = "";
            yield return new WaitForSeconds(2);
        }
    }
}
