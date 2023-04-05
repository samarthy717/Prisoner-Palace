using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{    
    // Start is called before the first frame update
    Vector2 MoveInput;
    public Rigidbody2D myRigidbody;
    [SerializeField] float Runspeed = 10f;
    [SerializeField] float Jumpforce = 5f;
    [SerializeField] float LadderClimbSpeed = 5f;
    [SerializeField] float FireballSpeed = 5f;

    public Animator myanimator;
    CapsuleCollider2D mycapsule;
    Enemy nemeny;
    [SerializeField] GameObject FireBall;
    public bool isdead = false;
    public bool HasFired = false;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myanimator = GetComponent<Animator>();
        mycapsule = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isdead) {
            Run();
            FlipSprite();
        }
        if (myRigidbody.velocity.y == 0){myanimator.SetBool("isclimbing", false); }
    }
    void OnMove(InputValue Input)
    {
        MoveInput = Input.Get<Vector2>();
        Debug.Log("Hurray"); 
    }
    void Run()
    {
        Vector2 velocity = new Vector2(MoveInput.x*Runspeed,myRigidbody.velocity.y);
        myRigidbody.velocity = velocity;
        myanimator.SetBool("isrunning", true);
        if(myRigidbody.velocity.x==0) myanimator.SetBool("isrunning", false);
    }
    void OnFire()
    {
        //if (HasFired) { return; }
        Debug.Log("Fire");
       Instantiate(FireBall,new Vector2(myRigidbody.position.x, myRigidbody.position.y), Quaternion.identity);
        HasFired = true;
    }
    void OnJump(InputValue value)
    {
        if (!isdead) {
            {
                if (!mycapsule.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }
                myRigidbody.velocity += new Vector2(0f, Jumpforce);
                Debug.Log("sex");
            } 
        }
    }
    void OnClimbing()
    {
        float initialGravity = myRigidbody.gravityScale;
        if (!mycapsule.IsTouchingLayers(LayerMask.GetMask("ladder"))){
          //myRigidbody.gravityScale = initialGravity;
         myanimator.SetBool("isclimbing", false);
            return;
        }
        Debug.Log("climb");
        Vector2 climbvelocity = new Vector2(myRigidbody.velocity.x, MoveInput.y *LadderClimbSpeed);
        myRigidbody.velocity = climbvelocity;
        bool playerhasVerticalSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;
        //myRigidbody.gravityScale = 0f;
        myanimator.SetBool("isclimbing",playerhasVerticalSpeed);

    }
    void FlipSprite()
    {
        bool PlayerHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if(PlayerHorizontalSpeed)
        transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x),1f);
    }


}
