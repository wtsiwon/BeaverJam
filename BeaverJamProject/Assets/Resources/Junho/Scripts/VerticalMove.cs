using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VerticalMove : MonoBehaviour
{
    public Rigidbody rb => GetComponent<Rigidbody>();
    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        if(GameManager.Instance.isGameStart)
        rb.velocity = Vector3.back * Time.deltaTime * GameManager.Instance.movingElementSpd;   
    }
}
