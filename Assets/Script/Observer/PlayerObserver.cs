using UnityEngine;

public class PlayerObserver : MonoBehaviour
{
    void Start()
    {
        PlayerActions.OnDead += OnLose;
        PlayerActions.OnWin += OnWin;
    }

    void OnDisable()
    {
        PlayerActions.OnDead -= OnLose;
        PlayerActions.OnWin -= OnWin;
    }

    private void OnLose()
    {
        GameManager.instance.Lose();
        StopAllCoroutines();

        Destroy(gameObject);
    }
    
    private void OnWin()
    {
        GameManager.instance.Win();
        StopAllCoroutines();
    }
}

