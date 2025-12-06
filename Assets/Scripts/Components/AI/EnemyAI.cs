using UnityEngine;
using UnityEngine.AI;

// ВАЖНО: Наследуем от Character, чтобы получить метод Initialize
public class EnemyAI : Character 
{
    // --- Состояния ИИ ---
    public enum AIState { Idle, MoveToTarget, Attack }
    public AIState currentState = AIState.Idle; 

    // --- Переменные для NavMesh и Target ---
    private NavMeshAgent agent;
    public Transform target; // Цель, которую нужно преследовать (Player)
    
    // --- Переменные для логики атаки ---
    public float attackRange = 1.5f; 
    public int attackDamage = 1; 
    public float attackCooldown = 1f; 
    private float lastAttackTime;

    // Используем Awake для инициализации данных и вызова SetupAI
    void Awake()
    {
        // 1. Создание данных (для врага)
        CharacterData enemyData = new CharacterData(
            speed: 3.5f, 
            health: 1, 
            name: "Враг"
        );

        // 2. Вызов Initialize родителя (IInputReader тут null)
        Initialize(enemyData, null);
    }

    // Здесь мы выполним всю логику, которая раньше была в Start()
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
        if (target == null)
        {
            GameObject playerObject = GameObject.FindWithTag("Player");
            if (playerObject != null)
            {
                target = playerObject.transform;
            }
        }
        
        if (agent == null)
        {
            Debug.LogError("EnemyAI требует компонент NavMeshAgent на объекте Enemy!");
        }

        // Устанавливаем скорость агента, используя новые данные:
        if (agent != null && Data != null)
        {
            agent.speed = Data.movementSpeed;
        }

        currentState = AIState.MoveToTarget; 
    }
    
    // Переопределяем Initialize, хотя не добавляем логику, чтобы соответствовать сигнатуре
    public override void Initialize(CharacterData data, IInputReader inputReader)
    {
        base.Initialize(data, inputReader);
    }
    
    // ... (Оставляем методы Update() и PerformAttack() без изменений) ...

    void Update()
    {
        if (target == null || agent == null) return;

        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        
        // --- Логика Смены Состояний (внешние переходы) ---
        if (distanceToTarget <= attackRange)
        {
            currentState = AIState.Attack; 
        }
        else if (distanceToTarget > attackRange)
        {
            currentState = AIState.MoveToTarget; 
        }
        
        // --- Выполнение Текущего Состояния ---
        switch (currentState)
        {
            case AIState.Idle:
                agent.isStopped = true;
                break;
            case AIState.MoveToTarget:
                agent.SetDestination(target.position);
                agent.isStopped = false;
                break;
            case AIState.Attack:
                agent.isStopped = true; 
                PerformAttack();
                break;
        }
    }

    private void PerformAttack()
    {
        if (Time.time > lastAttackTime + attackCooldown)
        {
            HealthComponent health = target.GetComponent<HealthComponent>();
            
            if (health != null)
            {
                health.TakeDamage(attackDamage); 
            }
            
            lastAttackTime = Time.time;
        }
    }
}