using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : VeticalMove
{
    [SerializeField] private Transform startPos;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("MapEndPos"))
        {
            transform.position = startPos.position;
        }
    }
}
