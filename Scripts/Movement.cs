using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 1f;
    public float runSpeed = 4f;
    public bool keyPressed = false;
    
    private void Update()
    {
        PlayerMovement();
        if (Input.GetKey(KeyCode.LeftShift ))
        {
            keyPressed = true;
        }
        else
        {
            keyPressed = false;
        }
    }
    private void OnCollisionEnter(Collision sejan )
    {
        Debug.Log("i hit something");
    }
    public void PlayerMovement()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        transform.position = transform.position + direction.normalized * speed * Time.deltaTime;
        switch (keyPressed)
        {
            case true:
                speed = 4f;
                break;
            default:
                speed = 1f;
                break;
        }
    }
}