using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy;
    // Start is called before the first frame update
    [SerializeField]
    private GameObject _rectangle;
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
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 rectanglePos = _rectangle.transform.position;
            float halfWidth = _rectangle.transform.localScale.x / 2f;
            float randomX = Random.Range(rectanglePos.x - halfWidth, rectanglePos.x + halfWidth);
            Vector3 spawnPos = new Vector3(randomX, rectanglePos.y, rectanglePos.z);
            Instantiate(_enemy, spawnPos, Quaternion.identity);
        }
    
    }
}
