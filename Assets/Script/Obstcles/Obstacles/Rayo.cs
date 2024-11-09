using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Rendering;

public class Rayo : MonoBehaviour{

    [SerializeField] private float speedX;
    [SerializeField] private float speedY;
    [SerializeField] private float timer = 0f;
    private bool isHit;
    private Rigidbody2D rb;

    float currentTime = 0;
    bool revertTimeBack = false;
    Movement movPlayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector2(speedX, speedY) * Time.deltaTime);

        currentTime += Time.deltaTime;
        if(revertTimeBack && timer <= currentTime)
        {
            movPlayer.InvertDirection();
            revertTimeBack = false;
            
        }

        // Si sale de la pantalla se destruye
        if (transform.position.y < -6 || transform.position.x < -15)
        {
            Destroy(gameObject);
        }

        if (isHit)
        {
            StartCoroutine(RespawnTime());
        }

    }

    private IEnumerator RespawnTime()
    {
        yield return new WaitForSeconds(0);

        isHit = false;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.CompareTag("Player"))
        {
            movPlayer = collision.gameObject.GetComponent<Movement>();
            movPlayer.InvertDirection();

            Destroy(gameObject);
           
            
        }
    }
}

