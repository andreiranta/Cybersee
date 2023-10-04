using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class wasd : MonoBehaviour
{
    public float moveSpeed;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    PhotonView view;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        view = GetComponent<PhotonView>();
        if (view.IsMine) { 
            foreach (var item in GetComponentsInChildren<Renderer>()) 
            {
                item.enabled = false;
            }
        }
    }
    private void myInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (view.IsMine)
        {
            MovePlayer();
        }
    }
    // Update is called once per frame
    void Update()
    {
        myInput();
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
}
