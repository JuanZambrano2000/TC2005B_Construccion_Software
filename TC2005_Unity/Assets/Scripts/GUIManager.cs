using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Assertions;

public class GUIManager : MonoBehaviour
{
    //Singleton
    // design pattern que limita la creacion de obejtos de una clase a solo uno
    //Lo hace limitando el acceso al constructor

    //Por las restriccione sde unity en lugar de constructor privado
    //Vamos a borrar nuevas instancias
    //static= atributo de clase, no objeto
    private static GUIManager _instance;
    

    //PROPERTIES
    //mecanismo para dividir quien puede leer/excribir una variable

    //podemos utilizarlos con variables explicitamente declaradas
    private float _dummy1;

    //escribiendo propiedad
    public float Dummy1{
        get{
            return _dummy1;
        }
        private set{
            _dummy1 = value;
        }
    }

    // propiedad con variable anonima
    public float Dummy2{
        get;
        private set;
    }

    public static GUIManager Instance{
        get{
            return _instance;
        }
    }
    [SerializeField]
    public TMP_Text _texto;
    
    void Awake(){
        //Pruebas con propiedades
        Dummy1 = 4.2f;
        print(Dummy1);
        // checar si alguien ya poblo la referencia de instancia
        if(_instance != null){
            //ya existia el objeto entonces me borro
            Destroy(gameObject);
            return;
        }
        _instance = this;
    }
    //private
    // Start is called before the first frame update
    void Start()
    {
        Assert.IsNotNull(_texto,"El texto no puede ser nulo");
        _texto.text = "Hola desde el codigo";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
