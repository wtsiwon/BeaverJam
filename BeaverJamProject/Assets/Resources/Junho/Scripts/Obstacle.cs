using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : VeticalMove
{
    public bool isOneBlock;
    private void Broken()
    {
        // ºÎ¼ÅÁü
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MapEndPos"))
        {
            Spawner.Instance.ObjPush(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            //switch (ÇÃ·¹ÀÌ¾î »óÅÂ)
            //{
            //    case Basic:
            //        Die
            //        break;
            //    defalut : 
            //        Broken();
            //        break;
            //}
        }
    }
}
