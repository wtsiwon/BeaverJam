using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBomb : VerticalMove
{
    [SerializeField] private GameObject target;
    const float waterPosZ = -50;
    protected override void Update()
    {
        base.Update();
        if (rb.position.z <= waterPosZ)
        {
            rb.position = target.transform.position + new Vector3(0, 0, 45);
        }    
    }
}
