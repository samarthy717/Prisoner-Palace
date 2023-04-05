using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    Rigidbody2D myrigidbody;
    PlayerInput popo;
    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        popo = FindObjectOfType <PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        float a = popo.myRigidbody.transform.localScale.x;
        myrigidbody.velocity = new Vector2(10f*a, 0f);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.CompareTag("Ground"))
        {
            if (popo.HasFired)
            {
                //Destroy(gameObject);
                //Debug.Log("Close");
                //popo.HasFired = false;
            }
        }

    }
}
