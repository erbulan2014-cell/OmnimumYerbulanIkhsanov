using UnityEngine;

// Эта строчка добавляет пункт в меню создания файлов Unity
[CreateAssetMenu(fileName = "NewSkillData", menuName = "Data/Skill Data Config")]
public class SkillDataConfig : ScriptableObject
{
    [Header("Информация о навыке")]
    public string skillName = "Название навыка";
    
    [TextArea(3, 5)] // Делает поле описания удобным и многострочным
    public string description = "Описание того, что делает этот навык.";
    
    public int cost = 100; // Цена
    
    public Sprite icon; // Сюда можно будет перетащить картинку иконки
}