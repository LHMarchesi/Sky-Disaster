using UnityEngine;
public class ObstaclesMovement : MonoBehaviour
{
    public float speedX;   
    public float speedY;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.AddForce(new Vector2(speedX, speedY) * Time.deltaTime);

        if (transform.position.y < -6 || transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
