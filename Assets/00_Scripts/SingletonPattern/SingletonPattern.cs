using UnityEngine;

public class SingletonPattern : MonoBehaviour
{
    private static SingletonPattern instance = null;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
