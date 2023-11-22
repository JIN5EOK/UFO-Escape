using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Actor : MonoBehaviour
{
    public event Action<Actor> onDestoryed;
    
    public void OnDestroy()
    {
        onDestoryed?.Invoke(this);
    }
}
