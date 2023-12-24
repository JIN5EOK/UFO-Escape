using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class VfxDelete : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    
    void Update()
    {
        if (_particleSystem.isPlaying == false)
        {
            Destroy(this.gameObject);
        }
    }
}
