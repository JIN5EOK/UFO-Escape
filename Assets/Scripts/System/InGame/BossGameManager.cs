using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGameManager : GameManager
{
    protected void Start()
    {
        base.Start();
        AudioManager.Instance.PlayBgm(AudioManager.Bgms.music_8bit_jammer);
    }
}
