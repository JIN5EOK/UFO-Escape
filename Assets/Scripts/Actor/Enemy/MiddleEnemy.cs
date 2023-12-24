using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleEnemy : CommonEnemy
{
    protected override void Start()
    {
        base.Start();
        Status.onDied += () =>
        {
            ResourcesManager.Instance.Instantiate(ResourcesManager.ACTOR_PATH + "MiniMiddleEnemy").transform.position =
                this.transform.position;
            ResourcesManager.Instance.Instantiate(ResourcesManager.ACTOR_PATH + "MiniMiddleEnemy").transform.position =
                this.transform.position;
        };
    }
}
