using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : ScrollMap
{
    private Transform startPos;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("MapEndPos"))
        {
            transform.position = startPos.position;
        }
    }
}
