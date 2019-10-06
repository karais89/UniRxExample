using Photon.Pun;
using UnityEngine;

public class PhotonSingletonMonoBehaviourFast<T> : MonoBehaviourPunCallbacks
    where T : PhotonSingletonMonoBehaviourFast<T>
{
    private static readonly string[] FindTags =
    {
        "GameController",
    };

    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                var type = typeof(T);
                foreach (var tag in FindTags)
                {
                    var objs = GameObject.FindGameObjectsWithTag(tag);
                    foreach (var go in objs)
                    {
                        _instance = (T) go.GetComponent(type);
                        if (_instance != null)
                            return _instance;
                    }
                }

                Debug.LogWarning($"{type.Name} is not found");
            }

            return _instance;
        }
    }

    protected virtual void Awake()
    {
        CheckInstance();
    }

    protected bool CheckInstance()
    {
        if (_instance == null)
        {
            _instance = (T) this;
            return true;
        }
        else if (Instance == this)
        {
            return true;
        }

        Destroy(this);
        return false;
    }
}