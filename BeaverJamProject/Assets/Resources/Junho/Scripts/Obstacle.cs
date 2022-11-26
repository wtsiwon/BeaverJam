using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : VerticalMove
{
    public bool isOneBlock;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MapEndPos"))
        {
            Spawner.Instance.ObjPush(gameObject);
        }
        if (other.CompareTag("Player"))
        {
            if (Player.Instance.IsBooster == false)
            {
                GameManager.Instance.GameOver();
            }
            else
            {
                GameManager.Instance.Score += 100;
            }
        }
    }
}
