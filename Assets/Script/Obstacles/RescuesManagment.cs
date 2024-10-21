using UnityEngine;

public class RescuesManagment : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.AddForce(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dead"))
        {
            Destroy(gameObject);
        }
    }
}
