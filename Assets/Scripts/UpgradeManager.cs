using System.Collections.Generic; // Нужно для работы со списками (List)
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [Header("Настройки")]
    // Сюда мы перетащим объект Content из Scroll View
    public Transform contentContainer; 
    
    // Сюда мы перетащим наш Префаб из папки Prefabs
    public SkillUIItem skillPrefab;    

    [Header("Данные навыков")]
    // Сюда мы добавим файлы HealthSkill и SpeedSkill
    public List<SkillDataConfig> skillsToSpawn; 

    void Start()
    {
        // Пробегаемся по списку всех навыков, которые мы добавили
        foreach (SkillDataConfig skill in skillsToSpawn)
        {
            // 1. Создаем копию кнопки (префаба) внутри Content
            SkillUIItem newButton = Instantiate(skillPrefab, contentContainer);
            
            // 2. Передаем кнопке данные (имя, цену, описание)
            newButton.Initialize(skill);
        }
    }
}