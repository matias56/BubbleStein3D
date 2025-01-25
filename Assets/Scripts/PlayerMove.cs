using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 10;

    private CharacterController cc;

    private Vector3 inputVector;
    private Vector3 movementVector;
    private float gravity = -10f;

    public Animator camAnim;

    private bool isWalking;

    public float momentumDamping = 5f;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();

        MovePlayer();


        camAnim.SetBool("isWalking", isWalking);
    }

    

    private void MovePlayer()
    {
        cc.Move(movementVector * Time.deltaTime);
    }

    private void GetInput()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

            inputVector.Normalize();

            inputVector = transform.TransformDirection(inputVector);

            isWalking = true;
        }
        else
        {
            inputVector = Vector3.Lerp(inputVector, Vector3.zero, momentumDamping * Time.deltaTime);

            isWalking = false;
        }



        movementVector = (inputVector * speed) + (Vector3.up * gravity);
    }
}
