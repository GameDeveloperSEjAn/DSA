using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotation : MonoBehaviour
{
    public Vector3 rotationPerSecond;
    void Update()
    {
        transform.Rotate(rotationPerSecond * Time.deltaTime );
    }
}
