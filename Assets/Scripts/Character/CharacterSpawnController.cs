using UnityEngine;
using System.Collections.Generic;

public class CharacterSpawnController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject enemyPrefab; // Ссылка на префаб врага
    [SerializeField] private Transform playerTransform; // Ссылка на игрока
    [SerializeField] private float spawnRadius = 10f; // Радиус спавна
    [SerializeField] private float spawnInterval = 1f; // Интервал спавна (сек)
    
    [Header("Difficulty Settings")]
    [SerializeField] private int initialMaxEnemies = 5; // Стартовый лимит
    [SerializeField] private int enemiesAddedPerMinute = 2; // Прирост сложности

    // Внутренние переменные
    private float matchTimer;
    private float spawnTimer;
    private int currentMaxEnemies;
    private bool isGameActive = true;

    private List<GameObject> activeEnemies = new List<GameObject>();

    private void Start()
    {
        currentMaxEnemies = initialMaxEnemies;
        
        // Автоматический поиск игрока, если забыл указать в инспекторе
        if (playerTransform == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null) playerTransform = player.transform;
        }
    }

    private void Update()
    {
        if (!isGameActive || playerTransform == null) return;

        UpdateTimers();
        HandleDifficultyScaling();
        HandleSpawning();
        CleanupDeadEnemies();
    }

    private void UpdateTimers()
    {
        matchTimer += Time.deltaTime;
        spawnTimer += Time.deltaTime;
    }

    private void HandleDifficultyScaling()
    {
        // Каждую минуту увеличиваем лимит врагов
        int minutesPassed = Mathf.FloorToInt(matchTimer / 60f);
        currentMaxEnemies = initialMaxEnemies + (minutesPassed * enemiesAddedPerMinute);
    }

    private void HandleSpawning()
    {
        if (spawnTimer >= spawnInterval && activeEnemies.Count < currentMaxEnemies)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
    }

    // === ГЛАВНОЕ ИЗМЕНЕНИЕ ЗДЕСЬ ===
    private void SpawnEnemy()
    {
        // 1. Выбираем случайную точку вокруг игрока
        Vector2 randomPoint = Random.insideUnitCircle.normalized * spawnRadius;
        Vector3 spawnPosition = playerTransform.position + new Vector3(randomPoint.x, 0, randomPoint.y);

        // 2. Создаем врага
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // 3. Находим на новом враге скрипт EnemyAI и говорим ему, кто цель
        var enemyScript = newEnemy.GetComponent<EnemyAI>(); 
        if (enemyScript != null)
        {
            enemyScript.target = playerTransform; // Передаем игрока как цель
        }

        // 4. Добавляем в список
        activeEnemies.Add(newEnemy);
    }
    // ===============================

    private void CleanupDeadEnemies()
    {
        // Удаляем из списка пустые ссылки (убитых врагов)
        activeEnemies.RemoveAll(item => item == null);
    }
    
    public void StopSpawning()
    {
        isGameActive = false;
    }
}