using System.Collections;
using System.Collections.Generic;
using DesignPattern.Singleton;
using UnityEngine;

public class ResourcesManager : MonoSingleton<ResourcesManager>
{
    public static readonly string UI_PATH = "Prefabs/UIs/";
    public static readonly string ACTOR_PATH = "Prefabs/Actors/";
    public static readonly string BGM_PATH = "Audios/Bgms/";
    public static readonly string SFX_PATH = "Audios/Sfxs/";



    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject go = Resources.Load<GameObject>(path);
        return Instantiate(go, parent);
    }
    public T GetResource<T>(string path) where T : Object
    {
        T obj = Resources.Load<T>(path);
        return obj;
    }
    public T[] GetResources<T>(string path) where T : Object
    {
        T[] obj = Resources.LoadAll<T>(path);
        return obj;
    }
}
