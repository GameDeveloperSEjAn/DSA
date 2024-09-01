using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("references")]
    public Transform trans;

    [Header("Stats")]
    [Tooltip("speed in units per second.")]
    public float speed = 34f;
    [Tooltip("max distance the projectile will be able to Travel")]
    public float range = 70f;
    private Vector3 spawnPoint;
    void Start()
    {
        spawnPoint = trans.position;
    }

    void Update()
    {
        trans.Translate(0,0, speed *  Time.deltaTime , Space.Self );
        if (Vector3.Distance(trans.position, spawnPoint) >= range)
        {
            Destroy(gameObject);
        }
    }
}
