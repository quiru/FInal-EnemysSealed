using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generador : MonoBehaviour
{
    public static bool isPlaying = true; //variable general para el fin del juego
    public GameObject heroe;
    GameObject ciudadano;
    GameObject items;
    public GameObject malo1;
    public GameObject malo2;
    Malo1.DatosMalo1 utilMalo1;
    Malo2.DatosMalo2 utilMalo2;
    public Text mensGamover;
    public Text contMalo1;
    public Text contMalo2;
    public Text mensCiudadano;
    public Text salud;

    int numMalo1;
    int numMalo2;

    void Start()
    {
        heroe = GameObject.Instantiate(heroe) as GameObject; //crea el heroe
        heroe.AddComponent<PersHero>(); //adiere el script del comportamiento del heroe
        heroe.AddComponent<MoviFps>(); // script de mov
        heroe.AddComponent<Rigidbody>().drag = 4; //le adiere rigidbody y le da 4 de grass para que no se resbale al chocar
        GameObject movCam = new GameObject(); //crea un objeto para añadirle la camara y el script de la camara y volverlo hijo del heroe
        movCam.AddComponent<Camera>().fieldOfView = 96f; //para ampliar la vista de la camara
        movCam.AddComponent<CamFps>();
        movCam.transform.SetParent(heroe.transform);
        movCam.transform.position = new Vector3(0, 1, 0);
        movCam.transform.localPosition = new Vector3(0.05f, 0.8f, 0.06f);
        heroe.transform.position = new Vector3(Random.Range(5, 20), 1, Random.Range(5, 45));

        int cantidadCiud = Random.Range(1, 9); //numero random de ciudadanos
        for (int i = 0; i < cantidadCiud; i++) //para crear la cantidad
        {
            ciudadano = GameObject.CreatePrimitive(PrimitiveType.Cube); 
            ciudadano.AddComponent<Ciudadano>();
            ciudadano.transform.position = new Vector3(Random.Range(5, 45), 1, Random.Range(5, 45));
            ciudadano.GetComponent<Renderer>().material.color = Color.gray;
            ciudadano.AddComponent<Rigidbody>();
            ciudadano.transform.name = "Ciudadanito";
        }

        int cantidadMal = Random.Range(8, 12); // numero random de enemigos
        for (int i = 0; i < cantidadMal; i++) //crea la cantidad
        {
            int escojer = Random.Range(0, 2); //para escojer un tipo u otro de malo
            if (escojer == 0)
            {
                malo1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                malo1.AddComponent<Malo1>(); //adiere script de comportamiento de malo1
                malo1.transform.localScale = new Vector3(1, 2, 1);
                malo1.transform.position = new Vector3(Random.Range(5, 23), 1, Random.Range(5, 45));
                utilMalo1 = malo1.GetComponent<Malo1>().utilMal1;
                malo1.GetComponent<Renderer>().material.color = utilMalo1.colorMalo;
                malo1.AddComponent<Rigidbody>();
                malo1.name = "malo1";
            }
            else
            {
                malo2 = Instantiate(malo2) as GameObject;
                malo2.AddComponent<Malo2>(); //adiere script de comportamiento de malo2
                malo2.transform.position = new Vector3(Random.Range(25, 45), 0, Random.Range(5, 45));
                utilMalo2 = malo2.GetComponent<Malo2>().utilMal2;
                malo2.GetComponent<Renderer>().material.color = utilMalo2.colorMalo;
                malo2.name = "malo2";
            }
        }

        int cantidadItem = Random.Range(1, 11); //numero random de items para recojer
        for (int i = 0; i < cantidadCiud; i++)
        {
            items = GameObject.CreatePrimitive(PrimitiveType.Cube); //crea los items
            items.transform.position = new Vector3(Random.Range(5, 45), 0.5f, Random.Range(5, 45));
            items.GetComponent<Renderer>().material.color = Color.yellow;
            items.transform.localScale = new Vector3(.3f, .3f, .3f);
            items.AddComponent<Rigidbody>();
            items.transform.name = "items";
        }

    }

    
    void Update()
    {
        numMalo1 = 0; //cuenta los malos en la escena
        numMalo2 = 0;
        foreach (Malo1 i in Transform.FindObjectsOfType<Malo1>()) //sie es tipo 1 lo suma
        {
            numMalo1 += 1;
        }

        foreach (Malo2 i in Transform.FindObjectsOfType<Malo2>()) //si es tipo 2 lo suma
        {
            numMalo2 += 1;
        }
        contMalo1.text = "malo 1: " + numMalo1; //muestra la cantidad de malos
        contMalo2.text = "malo 2: " + numMalo2;

        if (numMalo1 == 0 || numMalo2 == 0) //verifica si el numero de malos es 0 y acaba el juego y da el mensaje
        {
            isPlaying = false;
            mensGamover.text = "GANASTE, lo lograste";
        }
    }
}
