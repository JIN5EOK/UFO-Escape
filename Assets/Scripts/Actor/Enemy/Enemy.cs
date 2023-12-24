using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Enemy : Actor
{
    protected override void Start()
    {
        base.Start();
        Status.onDied += () =>
        {
            ResourcesManager.Instance.Instantiate(ResourcesManager.VFX_PATH + "FX_DEATH_AA").transform.position =
                this.transform.position;
            AudioManager.Instance.PlaySfx(AudioManager.Sfxs.mouse_emote_09);
            Destroy(this.gameObject);
        };
    }
}