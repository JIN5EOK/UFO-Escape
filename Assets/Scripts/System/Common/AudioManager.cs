using System.Collections;
using System.Collections.Generic;
using DesignPattern.Singleton;
using UnityEditor.SceneManagement;
using UnityEngine;

public class AudioManager : MonoSingleton<AudioManager>
{
    public enum Bgms
    {
        music_8bit_jammer, // 메인메뉴
        music_bytes_the_retro_adventure // 일반 스테이지
    }
    public enum Sfxs
    {
        ui_menu_button_click_01, // 버튼 클릭
        retro_jump_bounce_09, // 줍기
        retro_jump_bounce_20, // 던지기
        retro_impact_hit_13, // 적 피격 (물건에)
        retro_impact_hit_03, // 플레이어 피격
        explosion_large_01, // 폭발음
    }
    
    private Dictionary<string, AudioClip> bgms = new Dictionary<string, AudioClip>();
    private Dictionary<string, AudioClip> sfxs = new Dictionary<string, AudioClip>();

    private AudioSource bgmSource;
    private AudioSource sfxSource;
    private void Awake()
    {
        base.Awake();
        bgmSource = gameObject.AddComponent<AudioSource>();
        bgmSource.loop = true;
        bgmSource.volume = 0.5f;
        sfxSource = gameObject.AddComponent<AudioSource>();
        sfxSource.loop = false;
        
        var tempBgms = ResourcesManager.Instance.GetResources<AudioClip>(ResourcesManager.BGM_PATH);
        var tempSfxs = ResourcesManager.Instance.GetResources<AudioClip>(ResourcesManager.SFX_PATH);

        foreach (var b in tempBgms)
        {
            bgms.Add(b.name, b);
        }
        foreach (var s in tempSfxs)
        {
            sfxs.Add(s.name, s);
        }
    }
    
    public void PlayBgm(Bgms bgm)
    {   
        bgmSource.Stop();
        bgmSource.clip = bgms[bgm.ToString()];
        bgmSource.Play();
    }
    public void StopBgm()
    {
        bgmSource.Stop();
    }
    public void PlaySfx(Sfxs sfx)
    {
        sfxSource.PlayOneShot(sfxs[sfx.ToString()]);
    }
}
