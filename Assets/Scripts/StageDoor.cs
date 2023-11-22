using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageDoor : MonoBehaviour
{
    public void Start()
    {
        GameManager.Instance.onStageClear += OpenDoor;
    }

    public void OpenDoor()
    {
        Destroy(this.gameObject);
    }
}
