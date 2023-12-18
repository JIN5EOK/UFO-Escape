using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardKey : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<CockPit>().IsOpened = true;
            Destroy(this.gameObject);
        }
    }
}
