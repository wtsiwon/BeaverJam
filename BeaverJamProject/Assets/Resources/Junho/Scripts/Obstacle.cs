using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : VeticalMove
{
    public bool isOneBlock;
    private void Broken()
    {
        // �μ���
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            //switch (�÷��̾� ����)
            //{
            //    case Basic:
            //        Die
            //        break;
            //}
        }
    }
}
