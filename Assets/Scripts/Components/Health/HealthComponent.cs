using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    // Текущее здоровье персонажа
    public int currentHealth = 1;

    // Максимальное здоровье
    public int maxHealth = 1;
    
    // Флаг, который делает персонажа бессмертным (как в видео)
    public bool isImmortal = true; 

    // Метод для получения урона, вызывается скриптом EnemyAI
    public void TakeDamage(int damageAmount)
    {
        // Проверяем флаг бессмертия
        if (isImmortal)
        {
            Debug.Log("Ты глупый, я бессмертный!");
            return; 
        }

        currentHealth -= damageAmount;

        Debug.Log(gameObject.name + " получил урон. Здоровье: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Логика смерти
        Debug.Log(gameObject.name + " был уничтожен!");
        Destroy(gameObject);
    }
}