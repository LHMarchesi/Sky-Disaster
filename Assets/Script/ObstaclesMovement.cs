using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;


public class ObstaclesMovement : MonoBehaviour
{
 
    public float speedX;   
    public float speedY;
    private Rigidbody2D rb;
    void Start()
    {
        // Busca el componente Rigidbody
        rb = GetComponent<Rigidbody2D>();

            
    }

    private void Update()
    {
        // Se le añade una fuerza y se multiplica por el time delta time
        rb.AddForce(new Vector2(speedX, speedY) * Time.deltaTime);

        // Si sale de la pantalla se destruye
        if (transform.position.y < -6 || transform.position.x < -15)
        {
            Destroy(gameObject);
        }

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si colisiona con el jugador se destruye
        if (collision.CompareTag("Player"))
        {

            Destroy(gameObject);
        }
       
    }


}
