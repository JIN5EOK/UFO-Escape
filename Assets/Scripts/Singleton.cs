using System.Collections;
using UnityEngine;

namespace DesignPattern.Singleton 
{
    public class MonoSingleton<T> : MonoBehaviour where T : Component
    {
        protected static T instance;
        public static T Instance
        {
            get 
            {
                if (instance == null)
                {
                    var obj = GameObject.FindObjectOfType<T>();
                    if(obj == null)
                    {
                        var newObj = new GameObject(typeof(T).Name).AddComponent<T>();
                        instance = newObj;
                    }
                }
                return instance;
            }
        }

        public virtual void Awake()
        {
            if(instance == null) instance = this as T;
            else
            {
                if(instance != this) Destroy(gameObject);
            }
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public class Singleton<T> where T : class, new()
    {
        private static T instance = null;
        public static T Instance
        {
            get
            {
                if (instance == null)
                    instance = new T();

                return instance;
            }
        }
    }
}