using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float movespeed=5f;
    Rigidbody2D myrigidbody;
    PlayerInput Popo;
    float flag = 0;

    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        Popo = FindObjectOfType<PlayerInput>();
        flag = 1;
    }

    // Update is called once per frame
    void Update()
    {
        myrigidbody.velocity = new Vector2(movespeed, 0f);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collidedObject = collision.gameObject;

        if (collidedObject.tag == "Player")
        {
            death();
        }
        movespeed = -movespeed;
            FlipEnemySprite();
        
    }
    void FlipEnemySprite()
    {
        transform.localScale = new Vector2(-Mathf.Sign(myrigidbody.velocity.x),1f);
    }
    public void death()
    {
        Popo.isdead = true;
        Popo.myanimator.SetTrigger("Death");
        if (flag == 1) { Popo.myRigidbody.velocity += new Vector2(5f, 10f);flag = 0; }
        Debug.Log("death");
    }
}
