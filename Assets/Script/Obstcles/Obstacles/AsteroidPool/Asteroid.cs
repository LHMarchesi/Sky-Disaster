using System.Globalization;
using UnityEngine;
using UnityEngine.Pool;

public class Asteroid : MonoBehaviour, IDamageInteractable
{
    [SerializeField] private float timeoutDelay = 3f;

    public ObjectPool<Asteroid> pool;

    void OnEnable()
    {
        Invoke("Deactivate", timeoutDelay);
    }

    private void Deactivate()
    {
        pool.Release(this);
    }

    public void Interact()
    {
    }
}
