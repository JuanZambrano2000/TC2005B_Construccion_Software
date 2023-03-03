using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy;
    public Transform _spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        Assert.IsNotNull(_enemy,"No esta el enemy");
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.GetButtonDown("Fire1")){
            Instantiate(_enemy,
            transform.position,
            transform.rotation
            );
        }*/
        if(Input.GetButtonDown("Fire1")){
            Instantiate(_enemy,
            transform.position,
            transform.rotation
            );
        }
    
    }
}
