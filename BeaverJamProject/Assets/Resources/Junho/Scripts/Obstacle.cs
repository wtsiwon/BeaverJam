using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : VerticalMove
{
    public bool isOneBlock;
    private void OnTriggerEnter(Collider other)
    {
        string tag = other.tag;

        switch (tag)
        {
            case "MapEndPos":
                Spawner.Instance.ObjPush(gameObject);
                break;
            case "Player":
                if (Player.Instance.IsBooster == false)
                {
                    GameManager.Instance.GameOver();
                }
                else
                {
                    GameManager.Instance.Score += 100;
                }
                break;
            case "AddGauge":
                Player.Instance.gauge += 5f;
                break;
        }

    }
}
