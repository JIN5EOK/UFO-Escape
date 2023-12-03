using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICloseButton : MonoBehaviour
{
    [SerializeField] private UIBase closeTarget;
    
    public void Close()
    {
        closeTarget.CloseUI();
    }
}
