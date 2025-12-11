using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : Character
{
    private NavMeshAgent agent;
    private Transform target;
    private float timeSinceLastAttack = 0f;

    [Header("AI Settings")]
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private float attackCooldown = 2f;
    [SerializeField] private int attackDamage = 1;

    private enum AIState { Idle, MoveToTarget, Attack }
    private AIState currentState = AIState.Idle;

    public override void Initialize(Character character)
    {
        base.Initialize(character);
        
        agent = GetComponent<NavMeshAgent>();
        if (agent != null) agent.speed = character.Data.MovementSpeed;

        var playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null) target = playerObject.transform;

        currentState = AIState.MoveToTarget;
    }

    private void Update()
    {
        if (target == null) return;

        float dist = Vector3.Distance(transform.position, target.position);

        switch (currentState)
        {
            case AIState.MoveToTarget:
                if (dist <= attackRange)
                {
                    currentState = AIState.Attack;
                    agent.isStopped = true;
                }
                else
                {
                    agent.isStopped = false;
                    agent.SetDestination(target.position);
                }
                break;

            case AIState.Attack:
                if (dist > attackRange)
                {
                    currentState = AIState.MoveToTarget;
                }
                else
                {
                    if (Time.time >= timeSinceLastAttack + attackCooldown)
                    {
                        var health = target.GetComponent<HealthComponent>();
                        if (health != null) health.TakeDamage(attackDamage);
                        timeSinceLastAttack = Time.time;
                    }
                }
                break;
        }
    }
}