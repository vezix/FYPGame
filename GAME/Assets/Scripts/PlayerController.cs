using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    //public Rigidbody theRB;
    public float jumpForce;
    public CharacterController controller;
    public float gravityscale;
    public Animator anim;
    public Transform pivot;
    public float rotateSpeed;
    public GameObject playerModel;
    public float knockBackForce;
    public float knockBackTime;
    private float knockBackCounter;

    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        //theRB = GetComponent<Rigidbody>();  
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        /* theRB.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed,theRB.velocity.y, Input.GetAxis("Vertical") * moveSpeed);
         if (Input.GetButtonDown("Jump"))
         {
             theRB.velocity = new Vector3(theRB.velocity.x,jumpForce, theRB.velocity.z);
         } */

        //moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);
        if (knockBackCounter <= 0)
        {
            float yStore = moveDirection.y;
            moveDirection = (transform.right * Input.GetAxis("Horizontal")) + (transform.forward * Input.GetAxis("Vertical"));
            moveDirection = moveDirection.normalized * moveSpeed;
            moveDirection.y = yStore;

            if (controller.isGrounded)
            {
                moveDirection.y -= Physics.gravity.y * Time.deltaTime;
                /*if (Input.GetButtonDown("Jump"))
                {
                    moveDirection.y = jumpForce;
                }*/
            }
        } else
        {
            knockBackCounter -= Time.deltaTime;
        }
        moveDirection.y += (Physics.gravity.y * gravityscale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);

        //move player in different directions based on camera look direction
        
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }
        
        anim.SetBool("isGrounded", controller.isGrounded);
        anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical"))));
    }

    public void Knockback(Vector3 direction)
    {
        knockBackCounter = knockBackTime;
        moveDirection.y = knockBackForce;
        moveDirection = direction * knockBackForce;
    }
}
