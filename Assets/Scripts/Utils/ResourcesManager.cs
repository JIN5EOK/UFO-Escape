using System;
using System.Collections;
using System.Collections.Generic;
using DesignPattern.Singleton;
using UnityEngine;
using Object = UnityEngine.Object;

public class ResourcesManager : MonoSingleton<ResourcesManager>
{
    public static readonly string UI_PATH = "Prefab/UI/";
    public static readonly string ACTOR_PATH = "Prefab/Actor/";
    public static readonly string OBJECT_PATH = "Prefab/Object/";
    public static readonly string VFX_PATH = "Prefab/Vfx/";
    public static readonly string BGM_PATH = "Audio/Bgm/";
    public static readonly string SFX_PATH = "Audio/Sfx/";
    public static readonly string STAGE_PATH = "Scene/Stage/";
    public static readonly string LOBBY_PATH = "Scene/Lobby/";

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
