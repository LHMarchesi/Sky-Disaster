using System.Collections.Generic;
using UnityEngine;

enum States
{
    attack0, attack1, attack2,
}

public class EnemyAlien : Obstacle
{
    [SerializeField] private int Attack0speed;
    [SerializeField] private int Attack1speed;
    [SerializeField] private float rayInterval;
    private int _speed;
    private Vector2 _spawnPosition;
    private float nextRayTime;
    public override int speed { get => _speed; set => _speed = value; }
    public override Vector2 SpawnPosition { get => _spawnPosition; set => _spawnPosition = value; }

    private States currentState;
    private Animator animator;

    private bool isPositionSet;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        ChooseRandomState();
    }

    public override void Initialize()
    {
        switch (currentState)
        {
            case States.attack0:
                _spawnPosition = new Vector2(15f, 0.6f);
                transform.position = _spawnPosition;
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

    private void ChooseRandomState()
    {
        List<States> availableStates = new List<States> { States.attack0, States.attack1};
        currentState = availableStates[Random.Range(0, availableStates.Count)];
    }

    private void Attack0()
    {
        _speed = Attack0speed;
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void Attack1()
    {
        _speed = Attack1speed;
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
}
