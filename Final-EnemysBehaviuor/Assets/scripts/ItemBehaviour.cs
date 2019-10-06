using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            transform.parent = null;
            GetComponent<Rigidbody>().AddForce(transform.forward * 800);
            GetComponent<Rigidbody>().AddForce(transform.up * 10);
            GetComponent<Renderer>().enabled = true;
        }
    }
}
