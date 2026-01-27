using UnityEngine;
using TMPro;            // Нужно для работы с текстом
using UnityEngine.UI;   // Нужно для работы с кнопками

public class SkillUIItem : MonoBehaviour
{
    // Сюда мы перетащим наши текстовые поля и кнопку
    [Header("UI Элементы")]
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private Button buyButton;

    private SkillDataConfig _data; // Тут будем хранить данные этого скилла

    // Этот метод мы вызовем позже из главного менеджера
    public void Initialize(SkillDataConfig data)
    {
        _data = data;

        // Заполняем тексты данными из файла
        nameText.text = data.skillName;
        descriptionText.text = data.description;
        costText.text = data.cost.ToString() + " монет";
        
        // Настраиваем кнопку
        buyButton.onClick.RemoveAllListeners(); // Очищаем старые нажатия
        buyButton.onClick.AddListener(OnBuyClick); // Добавляем новое
    }

    private void OnBuyClick()
    {
        Debug.Log("Куплен скилл: " + _data.skillName);
        // Позже сюда добавим списание денег
    }
}