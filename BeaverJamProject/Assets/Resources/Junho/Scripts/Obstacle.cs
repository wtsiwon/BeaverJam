using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : VerticalMove
{
    public bool isOneBlock;
    private void Broken()
    {
        // �μ���
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
            //switch (�÷��̾� ����)
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
