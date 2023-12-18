using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICloseButton : MonoBehaviour
{
    [SerializeField] private UIBase closeTarget;
    
    public void Close()
    {
        AudioManager.Instance.PlaySfx(AudioManager.Sfxs.ui_menu_button_click_01);
        closeTarget.CloseUI();
    }
}
