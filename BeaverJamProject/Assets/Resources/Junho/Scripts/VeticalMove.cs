using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VeticalMove : MonoBehaviour
{
    Rigidbody rb => GetComponent<Rigidbody>();
    // Update is called once per frame
    void Update()
    {
        rb.transform.position += Vector3.back * Time.deltaTime;   
    }
}
