using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float timeToRevert = 3f;
    private Rigidbody2D playerRB;
    private Vector2 moveInput;
    private Animator animator;
    private float direction = 1f;
    private bool inverted = false;
    private float currentTime = 0f;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Se le asignan las Axis a una variable
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Se normalizan dentro de un vector para que tenga un movimiento uniforme en todas las direcciones
        moveInput = new Vector2(moveX, moveY).normalized;

        // Si el valor de moveX = 1 se ejecutara la animacion moving del jugador, y su componente FlipX sera falso
        if (moveX == 1)
        {
            animator.SetBool("Moving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        // Si el valor de moveX = -1 se ejecutara la animacion moving del jugador, y su componente FlipX sera verdadero haciendo que se cambie la direccion de este
        if (moveX == -1)
        {
            animator.SetBool("Moving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        // Si el valor de moveX = 0 este no se estara moviendo por lo cual la animacion moving no se ejecutara, en cambio se ejecutara la animacion idle
        if (moveX == 0)
        {
            animator.SetBool("Moving", false);
        }

        currentTime += Time.deltaTime;
        if (inverted && currentTime > timeToRevert)
        {
            RecoverDirection();
        }

    }

    private void FixedUpdate()
    {
        // Se mueve el jugador, sumando su posicion + su input y su velocidad 
        playerRB.MovePosition(playerRB.position + moveInput * speed * Time.fixedDeltaTime);   
    }

    public void InvertDirection()
    {
        if (!inverted)
        {
            inverted = true;
            direction *= -1;
        }
        currentTime = 0;
    }

    void RecoverDirection()
    {
        direction *= -1;
        inverted = false;
    }
}
