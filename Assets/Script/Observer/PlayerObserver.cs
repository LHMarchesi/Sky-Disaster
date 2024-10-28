using UnityEngine;

public class PlayerObserver : MonoBehaviour
{
    void Start()
    {
        PlayerActions.OnDead += Lose;
        PlayerActions.OnWin += Win;
    }

    void OnDisable()
    {
        PlayerActions.OnDead -= Lose;
        PlayerActions.OnWin -= Win;
    }

    private void Lose()
    {
        GameManager.instance.Lose();
        StopAllCoroutines();

        Destroy(gameObject);
    }
    
    private void Win()
    {
        GameManager.instance.Win();
        StopAllCoroutines();
    }
}

