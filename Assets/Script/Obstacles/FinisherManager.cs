using UnityEngine;

public class FinisherManager : MonoBehaviour
{
    [SerializeField]private GameObject finisher;

    void Update()
    {
        if (finisher.transform.position.x <= 5)
        {
            finisher.transform.position = new Vector2(5, -1);
        }
    }
}
