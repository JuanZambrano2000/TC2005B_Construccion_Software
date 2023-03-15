using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Ladrillo : MonoBehaviour
{
    private Rigidbody _rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //al presionar barra espaciadora vamos a detonar edxplosion
        /*if(Input.GetButtonDown("Jump")){
            _rigidBody.AddExplosionForce(10,
            new Vector3(433.69f,206.7f,-1.08f),
            5);
        }*/
        if(Input.GetButtonDown("Jump")){
            _rigidBody.AddExplosionForce(10000,
            new Vector3(-2.23f,3.26f,6.27f),
            5);
        }
    }
}
