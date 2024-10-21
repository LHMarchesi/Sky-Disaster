using UnityEngine;

public class Allie : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform Spawn;

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dead"))
        {
            Destroy(gameObject);
        }
    }
}
