using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Assertions;

public class GUIManager : MonoBehaviour
{
    [SerializeField]
    public TMP_Text _texto;
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
