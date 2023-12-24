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
            AudioManager.Instance.PlaySfx(AudioManager.Sfxs.retro_jump_bounce_09);
            FindObjectOfType<CockPit>().IsOpened = true;
            Destroy(this.gameObject);
        }
    }
}
