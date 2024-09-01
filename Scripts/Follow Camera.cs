using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;
    public float distance = 3;

    public float smoothTime = .25f;
    Vector3 currentVelocity;

    private void LateUpdate()
    {
        Vector3 target = player .position + (transform.position - player.position ).normalized * distance ;
        transform.position = Vector3 .SmoothDamp (transform.position , target , ref currentVelocity , smoothTime);
        transform.LookAt (player );
    }
}