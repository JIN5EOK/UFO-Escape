using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CockPit : MonoBehaviour
{
    private bool _isOpened;

    public bool IsOpened
    {
        get => _isOpened;
        set
        {
            _isOpened = value;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player" && _isOpened == true)
        {
            ResourcesManager.Instance.Instantiate(ResourcesManager.UI_PATH + "GameAllClearPanel");
        }
    }
}
