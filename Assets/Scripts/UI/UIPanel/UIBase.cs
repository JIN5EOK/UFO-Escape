using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIBase : MonoBehaviour
{
    public event Action onClose;
    public void CloseUI()
    {
        onClose?.Invoke();
        Destroy(this.gameObject);
    }
    
    private void OnEnable()
    {
        GameManager s = FindObjectOfType<GameManager>();
        if (s != null)
            s.StageState = GameManager.StageStates.Pause;
    }

    private void OnDisable()
    {
        GameManager s = FindObjectOfType<GameManager>();
        if (s != null)
            s.StageState = GameManager.StageStates.Play;
    }
}
