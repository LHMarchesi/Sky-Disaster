using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class RescuesManagment : MonoBehaviour
{
    [SerializeField]  private Rigidbody2D rb;
    private float speed;
    void Start()
    {
        // Valor de la velocidad
        speed = 15f;

        // Llama al componente rigidbody 
        rb= GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        // Movimiento por fuerza
        rb.AddForce(Vector2.left * speed * Time.deltaTime);
    }

    // Seguimiento de jugador

    private void OnTriggerEnter2D(Collider2D collision)
    {
    //Si colisiona con un objeto con el TAG "DEAD" se destruye
        if (collision.CompareTag("Dead"))
        {

            Destroy(gameObject);
        }
    }






}
