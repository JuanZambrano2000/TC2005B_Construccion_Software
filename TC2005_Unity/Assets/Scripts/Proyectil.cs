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

    void Start(){
        //Si ceras objetos dinamicamante
        //Es indispensable que tenga al menos una estrategia de destruccion
        // destroy - destruye game objects completos
        //o componentes
        Destroy(gameObject,_tiempoDeAutodestruccion);
        //Nota esto va a cambiar
    /*
        _gui = GUIManager.Instance;
        Assert.IsNotNull(_gui,"GUI manager nulo");
        _gui._texto.text = "Score: " + _score;*/
        StartCoroutine(CorrutinaDummy());
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
        //print("Enter"+c.transform.name);
    }
    void OnCollisionStay(Collision c){
        //print("Stay");
    }
    void OnCollisionExit(Collision c){
        //print("Exit");  
    }
    void OnTriggerEnter(Collider c){
        //print("Trigger enter");
        Destroy(gameObject);
    }
    void OnTriggerStay(Collider c){
        //print("Trigger stay");
    }
    void OnTriggerExit(Collider c){
        //print("Trigger exit");
    } 
    //CCORUTINAS
    //Cuando tenemos la necesidad de hacer codigo "concurrente" vamos a utilizar corrutinas
    //Se comportan como hilos (pero no son)

    //CASO DE USO 1 - cuando queremos correr algo con un retraso
    // tambien pueden usar invoke pero se recomienda corrutina
    IEnumerator CorrutinaDummy(){
        yield return new WaitForSeconds(2);
        print("Hola");
    }
    //CASO DE USO 2 - logica recurrente
    

    //CASO DE USO 3 - (no mostrado) - al esperar respuesta de codigo asincrono
}
