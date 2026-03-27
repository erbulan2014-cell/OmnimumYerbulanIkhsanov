using UnityEngine;
using System;

public class PlayerProgression : MonoBehaviour
{
    [Header("Настройки")]
    // Ссылка на твой синий файл ScriptableObject
    [SerializeField] private ProgressionConfig config; 

    [Header("Текущее состояние (для отладки)")]
    public int currentLevel = 1;
    public int currentXP = 0;

    // Событие, которое сообщает UI, что нужно обновиться
    public event Action OnChanged;

    private void Start()
    {
        // Сбрасываем прогресс при каждом запуске игры (требование ДЗ)
        ResetProgress();
    }

    private void Update()
    {
        // Тот самый "читерский" способ для теста:
        // При нажатии на ПРОБЕЛ добавляем 50 опыта
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddExperience(50);
        }
    }

    public void ResetProgress()
    {
        currentLevel = 1;
        currentXP = 0;
        
        // Оповещаем UI, что данные сброшены
        OnChanged?.Invoke();
    }

    public void AddExperience(int amount)
    {
        // Если уже достигли максимума, опыт больше не прибавляем
        if (currentLevel >= config.MaxLevel) return;

        currentXP += amount;

        // Получаем, сколько опыта нужно для текущего уровня
        int requiredXP = config.GetRequiredXP(currentLevel);

        // Проверяем: достаточно ли опыта для повышения?
        // Используем while на случай, если опыта пришло сразу на 2 уровня
        while (currentLevel < config.MaxLevel && currentXP >= requiredXP)
        {
            currentXP -= requiredXP; // Вычитаем "потраченный" на уровень опыт
            currentLevel++;          // Повышаем уровень
            
            Debug.Log($"Уровень повышен! Ваш текущий уровень: {currentLevel}");

            // Пересчитываем порог для следующего уровня (если он не максимальный)
            requiredXP = config.GetRequiredXP(currentLevel);
        }

        // В конце обязательно говорим UI: "Эй, обновись, цифры изменились!"
        OnChanged?.Invoke();
    }
}