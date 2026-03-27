using UnityEngine;
using TMPro; // Это пространство имен обязательно для работы с TextMeshPro

public class ProgressionUI : MonoBehaviour
{
    [Header("Ссылки на компоненты")]
    // Сюда в инспекторе перетащим объект Player
    [SerializeField] private PlayerProgression player; 
    
    // Сюда перетащим текстовые объекты, которые ты создал на шаге 5
    [SerializeField] private TextMeshProUGUI levelText; 
    [SerializeField] private TextMeshProUGUI xpText;    

    private void OnEnable()
    {
        // Подписываемся на "сообщение" от игрока о том, что опыт изменился
        if (player != null)
            player.OnChanged += UpdateUI;
    }

    private void OnDisable()
    {
        // Отписываемся, чтобы не было ошибок при выходе из игры
        if (player != null)
            player.OnChanged -= UpdateUI;
    }

    private void Start()
    {
        // Обновляем текст сразу при старте, чтобы не висело "New Text"
        UpdateUI(); 
    }

    // Метод, который берет цифры из скрипта игрока и рисует их в тексте
    private void UpdateUI()
    {
        if (player == null) return;

        levelText.text = $"Уровень: {player.currentLevel}";
        xpText.text = $"Опыт: {player.currentXP} XP";
        
        // Маленький бонус: если уровень максимальный, можно написать это
        // (config тут недоступен напрямую, поэтому просто выводим текущие данные)
    }
}