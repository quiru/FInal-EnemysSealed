using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovArma : MonoBehaviour //para mover el arma
{
    void Start()
    {
        GetComponent<Animator>().enabled = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) //si se presiona espacio el arma deberia moverse 
        {
            GetComponent<Animator>().enabled = true;
        }
        else
        {
            GetComponent<Animator>().enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "malo1" && Input.GetKey(KeyCode.Space))
        {
            collision.gameObject.GetComponent<Malo1>().restaVida -= 10;
        }
        else if (collision.transform.name == "malo2" && Input.GetKey(KeyCode.Space))
        {
            collision.gameObject.GetComponent<Malo1>().restaVida -= 10;
        }
    }
}
