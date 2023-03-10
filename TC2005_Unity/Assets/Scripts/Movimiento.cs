// Estamos usando .NET
// Aqui "importamos" namespaces
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

//OJO
// con esta directiva obligamos la presencia de un componente en el gameobject
// todos tienen transdorm asi que este ejemplo es redundante
//[RequireComponent{typeof(Transform)}]
public class Movimiento : MonoBehaviour
{
    // Va a haber situaciones en donde deba acceder a otro componente
    //Voy a necesitar una referencia

    //Atributo de clase _nombre
    private Transform _transform;
    
    private IEnumerator _ienumeratorCorrutina;

    private Coroutine _corrutina;
    // Modificar velocidad
    [SerializeField]
    private float _speed = 10;

    [SerializeField]
    private GameObject _disparoOriginal;
    
    //ciclo de vida / lifecycle
    // Existen metodos que se invocan en momentos especificos de la vida del script
    // Start is called before the first frame update
    //Se invoca una vez al inicio de la vida del componente
    void Awake()
    {
        print("Awake");
    }
    // Se invoca una vez despues que fueron invocados todos los awakes
    void Start()
    {
        Debug.Log("Start");
        // Como obtener referencia a otro componente

        //Notas 
        // -getcomponent es lento, hazlo la menor cantidad de veces posible
        // -  con transform ya tenemos referencia (ahorita lo vemos)
        // - Esta operacion puede regresar null
        _transform = GetComponent<Transform>();
        Assert.IsNotNull(_transform,"Es necesario para movimiento tener un transform");
        Assert.IsNotNull(_disparoOriginal,"DISPARO NO PUEDE SER NULO");
        //Assert.AreNotEqual(0,"Velocidad debe ser mayor a cero");
        StartCoroutine(CorrutinaDummy());
        //StartCoroutine(DisparoRecurrente());
        _ienumeratorCorrutina = DisparoRecurrente();
    }
    // Update is called once per frame
    // frame? cuadro?
    //Minimo - 30 fps, Target - 60 fps
    void Update()
    {
        //Debug.LogWarning("Update");  
        //Tratamos que sea lo mas magro posible
        //Update los usamos para dos cosas
        //1. Entrada de usuario
        //2. Movimiento
        //Vamos a hacer polling por dispositivo
        // boolean - true cuando en el cuadro anterior estaba libre y en este esta presionada
        /*
        if(Input.GetKeyDown(KeyCode.Z)){
            print("Key down: Z");
        }
        //True cuando en el cuadro anterior estaba presionada y en el actual sigue presionada
        if(Input.GetKey(KeyCode.Z)){
            print("Key: Z");
        }
        //True - estaba presionada
        // ya esta libre
        if(Input.GetKeyUp(KeyCode.Z)){
            print("Key Up: Z");
        }
        if(Input.GetMouseButtonDown(0)){
            print("Mouse button down");
        }
        if(Input.GetMouseButton(0)){
            print("Mouse button");
        }
        if(Input.GetMouseButtonUp(0)){
            print("Mouse button up");
        }
        */
        //Vamos a usar ejes (despues)
        //Mapeo de hardware a un valor abstracto llamado eje
        // hacemos polling a eje en lugar de hacerlo a hardware especifico
        //Raw
        //float horizontal = Input.GetAxisRaw("Horizontal");
        //Suavizado
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        //print(horizontal+" "+vertical);
        //Se pueden usar ejes como botones
        
        // Como mover objetos
        // 3 opciones
        // 1 - directamente con su transform
        // 2 - por medio de character controller
        // 3 - por medio del motor de fisica
        // 4 - por medio de navmesh (AI)

        //1
        //Time.deltaTime en lugar de tomar los frames toma un tiempo fijo
        //Space.World nos permite que avance en la X del mundo, no el objeto (por si esta rotado)
        _transform.Translate(
            horizontal *_speed*Time.deltaTime,
            vertical *_speed*Time.deltaTime,
            0,
            Space.World
            );
        if(Input.GetButtonDown("Jump")){
            /*
            //print("JUMP");
            //Se pueden hacer game objects vacios
            //GameObject objeto = new GameObject();
            //Si queremos un gameobject predefinido para clonar usamos instantiate
            Instantiate(_disparoOriginal,
            transform.position,
            transform.rotation
            );*/
            //Para detener una corrutina hay que tener referencia a ella en la construccion
            // metodo 1 - EL FEO (Usando Strings)
            //StartCoroutine("DisparoRecurrente");

            // metodo 2 - con IEnumerator
            //StartCoroutine(_ienumeratorCorrutina);
            // metodo 3 - referencia a corrutina
            _corrutina = StartCoroutine(DisparoRecurrente());
        }
        if(Input.GetButtonUp("Jump")){
            //StopAllCoroutines();
            //StopCoroutine("DisparoRecurrente");
            //StopCoroutine(_ienumeratorCorrutina);
            StopCoroutine(_corrutina);
        }

    }
    //Fixed? - fijo
    // update que corre en intervalo fijado en la configuracion del proyecto
    //No puede correr mas frecuentemente que update
    void FixedUpdate()
    {
        //Debug.LogError("Fixed update");   
    }
    //Corre todos los cuadros una vez que los updates estan terminados
    void LateUpdate(){
        //print("Late Update");  
    }

    IEnumerator CorrutinaDummy(){
        yield return new WaitForSeconds(2);
        print("Hola");
    }
    //CASO DE USO 2 - logica recurrente
    IEnumerator DisparoRecurrente(){
        while(true){
            /*Instantiate(_disparoOriginal,
            transform.position,
            transform.rotation);*/
            Instantiate(_disparoOriginal,
            transform.position,
            transform.rotation);
            yield return new WaitForSeconds(0.3f);
            //print("CORRUTINA RECURRENTE");
        }
    }    

    //CASO DE USO 3 - (no mostrado) - al esperar respuesta de codigo asincrono
}
