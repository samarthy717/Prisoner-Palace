using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazards : MonoBehaviour
{
    // Start is called before the first frame update
    Enemy nemeny;
    void Start()
    {
        nemeny = FindObjectOfType<Enemy>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collidedObject = collision.gameObject;

        if (collidedObject.tag == "Player")
        {
            nemeny.death();
        }
        

    }
}  
