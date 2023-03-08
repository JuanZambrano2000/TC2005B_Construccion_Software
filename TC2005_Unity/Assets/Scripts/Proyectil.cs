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
    private int _score = 0;

    void Start(){
        //Si ceras objetos dinamicamante
        //Es indispensable que tenga al menos una estrategia de destruccion
        // destroy - destruye game objects completos
        //o componentes
        Destroy(gameObject,_tiempoDeAutodestruccion);
        //Nota esto va a cambiar

        _gui = GUIManager.Instance;
        Assert.IsNotNull(_gui,"GUI manager nulo");
        _gui._texto.text = "Score: " + _score;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(
            0,
            0,
            _speed*Time.deltaTime
        );
        _gui._texto.text = "Score: " + _score;
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
        _score=_score+1;
        Destroy(gameObject);
    }
    void OnTriggerStay(Collider c){
        print("Trigger stay");
    }
    void OnTriggerExit(Collider c){
        print("Trigger exit");
    } 
}
