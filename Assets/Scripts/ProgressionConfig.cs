using UnityEngine;

[CreateAssetMenu(fileName = "ProgressionConfig", menuName = "Data/Progression Config")]
public class ProgressionConfig : ScriptableObject
{
    [Header("Настройки уровней")]
    [Tooltip("Массив опыта для перехода. Индекс 0 — опыт для 2-го уровня, индекс 1 — для 3-го и т.д.")]
    public int[] xpRequirements;

    // Свойство для получения максимального уровня
    public int MaxLevel => xpRequirements.Length + 1;

    // Метод для получения нужного опыта для конкретного уровня
    public int GetRequiredXP(int level)
    {
        int index = level - 1;
        if (index >= 0 && index < xpRequirements.Length)
        {
            return xpRequirements[index];
        }
        return 0; // Для макс. уровня или некорректного значения
    }
}