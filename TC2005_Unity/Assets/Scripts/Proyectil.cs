using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Proyectil : MonoBehaviour
{
    [SerializeField]
    private float _speed=5;
    [SerializeField]
    private float _tiempoDeAutodestruccion = 3;

    private GUIManager _gui;

    void Start(){
        //Si ceras objetos dinamicamante
        //Es indispensable que tenga al menos una estrategia de destruccion
        // destroy - destruye game objects completos
        //o componentes
        Destroy(gameObject,_tiempoDeAutodestruccion);
        //Nota esto va a cambiar
        GameObject guiGO = GameObject.Find("GUIManager");
        Assert.IsNotNull(guiGO, "No hay GUI manager");
        _gui = guiGO.GetComponent<GUIManager>();
        Assert.IsNotNull(_gui,"GUIManager no tiene componente");
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(
            0,
            0,
            _speed*Time.deltaTime
        );
    }
    //Colisionaes
    // Para checar colisiones con fisica necesitamos:
    // 1. todos los objetos involucrados requieren de un colider
    // 2. necesitamos que por lo menos uno tenga un rigidBody
    // 3. el rigidbody debe estar en un objeto que se mueva

    //El objeto collision tiene info de la colision
    void OnCollisionEnter(Collision c){
        print("Enter"+c.transform.name);
    }
    void OnCollisionStay(Collision c){
        print("Stay");
    }
    void OnCollisionExit(Collision c){
        print("Exit");  
    }
    void OnTriggerEnter(Collider c){
        print("Trigger enter");
    }
    void OnTriggerStay(Collider c){
        print("Trigger stay");
    }
    void OnTriggerExit(Collider c){
        print("Trigger exit");
        _gui._texto.text = "SALI " + transform.name;
    } 
}