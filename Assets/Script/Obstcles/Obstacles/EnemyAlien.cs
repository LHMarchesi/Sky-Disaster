using System.Collections.Generic;
using UnityEngine;

enum States
{
    attack0, attack1, attack2,
}

public class EnemyAlien : Obstacle
{
    [SerializeField] private int attack0speed;
    [SerializeField] private GameObject warningSprite;
    [SerializeField] private int attack1speed;
    [SerializeField] private float rayInterval;
    private Vector2 _spawnPosition;
    private float nextRayTime;
    public override int speed { get => _speed; set => _speed = value; }
    public override Vector2 SpawnPosition { get => _spawnPosition; set => _spawnPosition = value; }

    private States currentState;
    private Animator animator;

    private int _speed;
    private bool isPositionSet;
    private float timeoutDelay = 15f;
    private float warningDuration = 1f;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        ChooseRandomState();
    }

    public override void Initialize()
    {
        Invoke("Deactivate", timeoutDelay);

        switch (currentState)
        {
            case States.attack0:
                _spawnPosition = new Vector2(25f, 0.6f);
                transform.position = _spawnPosition;
                ShowWarning();
                break;

            case States.attack1:
                _spawnPosition = new Vector2(15f, 4f);
                transform.position = _spawnPosition;
                break;

            default:
                break;
        }
    }

    void Update()
    {
        switch (currentState)
        {
            case States.attack0:
                Attack0();
                break;
            case States.attack1:
                Attack1();
                break;
            default:
                break;
        }
    }

    private void ShowWarning()
    {
        Vector2 offset = new Vector2(-18, 0);
        warningSprite.transform.position = _spawnPosition + offset;
        warningSprite.gameObject.transform.SetParent(null);
        warningSprite.SetActive(true);

        Invoke("HideWarning", warningDuration);
    }

    private void ChooseRandomState()
    {
        List<States> availableStates = new List<States> { States.attack0, States.attack1 };
        currentState = availableStates[Random.Range(0, availableStates.Count)];
    }

    private void Attack0()
    {
        _speed = attack0speed;
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void Attack1()
    {
        _speed = attack1speed;
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (Time.time >= nextRayTime)
        {
            animator.SetBool("Attack1", true);
            nextRayTime = Time.time + rayInterval;
        }
        else
        {
            animator.SetBool("Attack1", false);
        }
    }

    private void HideWarning()
    {
        warningSprite.SetActive(false);
        StartAttack();
    }

    private void StartAttack()
    {
        Update();
    }

    private void Deactivate()
    {
        Destroy(gameObject);
    }
}
