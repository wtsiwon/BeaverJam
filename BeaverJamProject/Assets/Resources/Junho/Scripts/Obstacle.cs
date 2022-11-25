using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : VeticalMove
{
    public bool isOneBlock;
    private void Broken()
    {
        // 부셔짐
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            //switch (플레이어 상태)
            //{
            //    case Basic:
            //        Die
            //        break;
            //}
        }
    }
}
