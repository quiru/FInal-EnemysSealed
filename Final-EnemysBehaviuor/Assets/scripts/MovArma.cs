using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovArma : MonoBehaviour //para mover el arma
{
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) //si se presiona espacio el arma deberia moverse 
        {
            transform.right -= new Vector3(0.2f, 0, 0);
            if (transform.position.x <= -0.5) //si llega a ese vector que se devuelva 
            {
                transform.position += new Vector3(0.2f, 0, 0);
                if (transform.position.x >= 0.6) //si llega a ese vector que se quede quieto
                {
                    transform.position = new Vector3(0.6f, 0.1f, 0.7f);
                }
            }
            
        }
    } //pero no funciona muy bien
}
