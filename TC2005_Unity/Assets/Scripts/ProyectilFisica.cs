using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class ProyectilFisica : MonoBehaviour
{
    [SerializeField]
    private float _force;

    private Rigidbody _rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        //Vectores de referencia que siempre tenemos en el transform
        //Transform.up;
        //Transform.right;
        //Transform.forward;
        //Los vectores estan en el espacio del mundo
        //vectores siempre estan normalizados

        _rigidBody = GetComponent<Rigidbody>();
        /*
        _rigidBody.AddForce(
            new Vector3(0,_force,0),
            ForceMode.Impulse
        );*/
        _rigidBody.AddForce(
            transform.up*_force,
            ForceMode.Impulse
        );
    }

    void OncollisionEnter(Collision c){
        print("LAYER: " + c.gameObject.layer);
        print("TAGS: " + c.transform.tag);
    }
    
}
