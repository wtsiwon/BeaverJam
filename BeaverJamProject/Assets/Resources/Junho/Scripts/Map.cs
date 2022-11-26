using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : VerticalMove
{
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("MapEndPos"))
        {
            ScrollMap.Instance.NextMap(this.gameObject);
        }
    }
}
