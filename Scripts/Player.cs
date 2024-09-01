using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //References 
    [Header("References")]
    public Transform trans;
    public Transform modelTrans;
    public CharacterController characterController;

    //Movement
    [Header("Movement")]
    [Tooltip("Units moved per second at maximum speed")]
    public float moveSpeed = 24;

    [Tooltip("Time in seconds to reach maximum speed")]
    public float timeToMaxSpeed = .26f;

    private float velocityGainPerSecond 
    {
        get 
        {
            return moveSpeed / timeToMaxSpeed; 
        } 
    }

    [Tooltip("Time, in seconds, to go from maximum speed to stationary")]
    public float timeToLoseMaxSpeed = .2f;

    private float velocityLossPerSecond 
    {
        get 
        {
            return moveSpeed / timeToLoseMaxSpeed; 
        } 
    }

    [Tooltip("Multiplier for momentum when attempting to move in a direction opposite the current traveling direction ")]
    public float reverseMomentumMultiplier = 2.2f;

    private Vector3 movementVelocity = Vector3.zero;

    [Header("Death and Respawning ")]
    private float respawnWaitTime = .5f;
    private bool dead = false;
    private Vector3 spawnPoint;
    private Quaternion spawnRotation;

    private void Start()
    {
        spawnPoint = trans.position;
        spawnRotation = modelTrans.rotation;
    }
    void Update()
    {
        Movement();
    }
    private void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (movementVelocity.z >= 0 )
            {
                movementVelocity.z = Mathf.Min(moveSpeed, movementVelocity.z + velocityGainPerSecond * Time.deltaTime);
            }
            else
            {
                movementVelocity.z = Mathf.Min(0, movementVelocity.z + velocityGainPerSecond * reverseMomentumMultiplier * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (movementVelocity.z > 0)
            {

                movementVelocity.z = Mathf.Max(0, movementVelocity.z - velocityGainPerSecond * reverseMomentumMultiplier *Time.deltaTime);
            }
            else
            {
                movementVelocity.z = Mathf.Max(-moveSpeed , movementVelocity.z - velocityGainPerSecond * Time.deltaTime);
            }
        }
        else
        {
            if (movementVelocity.z > 0)
            {
                movementVelocity.z = Mathf.Max(0, movementVelocity.z - velocityGainPerSecond * Time.deltaTime);
            }
            else
            {
                movementVelocity.z = Mathf.Min (0, movementVelocity.z + velocityGainPerSecond * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.D ))
        {
            if (movementVelocity.x >= 0)
            {
                movementVelocity.x = Mathf.Min (moveSpeed , movementVelocity.x + velocityGainPerSecond * Time.deltaTime);
            }
            else
            {
                movementVelocity.x = Mathf.Min (moveSpeed , movementVelocity.x + velocityGainPerSecond  * reverseMomentumMultiplier * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (movementVelocity.x <= 0)
            {
                movementVelocity.x = Mathf.Max(-moveSpeed, movementVelocity.x - velocityGainPerSecond * Time.deltaTime);
            }
            else
            {
                movementVelocity.x = Mathf.Max (-moveSpeed, movementVelocity.x - reverseMomentumMultiplier *velocityGainPerSecond * Time.deltaTime);
            }
        }
        else
        {
            if (movementVelocity.x > 0)
            {
                movementVelocity.x = Mathf.Max (0f, movementVelocity.x - velocityLossPerSecond * Time.deltaTime);
            }
            else
            {
                movementVelocity.x = Mathf.Min (0f, movementVelocity.x + velocityLossPerSecond * Time.deltaTime);
            }
        }
        if (movementVelocity.x != 0 || movementVelocity.z != 0)
        {
            characterController.Move(movementVelocity * Time.deltaTime);
            modelTrans.rotation = Quaternion.Slerp(modelTrans.rotation, Quaternion.LookRotation(movementVelocity), .18f);
        }
    }
    public void Die()
    {
        if (!dead)
        {
            dead = true;
            movementVelocity = Vector3.zero;
            enabled = false;
            characterController.enabled = false;
            modelTrans.gameObject.SetActive(false);
            Invoke("Respawn", respawnWaitTime);
        }
    }
    void Respawn()
    {
        dead = false;
        trans.position = spawnPoint;
        modelTrans.rotation = spawnRotation;
        enabled = true;
        characterController.enabled = true;
        modelTrans.gameObject.SetActive(true);
    }
}