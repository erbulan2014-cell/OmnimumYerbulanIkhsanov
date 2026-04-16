using UnityEngine;

public class PassiveSkillManager : MonoBehaviour
{
    // Здесь хранится наша текущая "матрешка"
    private IStatsProvider _playerStats;
    
    // Ссылка на компонент персонажа, чтобы достать базовые данные
    private Character _character;

    void Start()
    {
        // Получаем компонент Character (который висит на том же объекте)
        _character = GetComponent<Character>();
        
        // Важно: GameInitializer у вас назначает Data в Awake, 
        // поэтому в Start данные уже будут готовы.
        if (_character != null && _character.Data != null)
        {
            // Собираем базовую матрешку
            _playerStats = new BasePlayerStats(_character.Data);
            Debug.Log($"[Декоратор] Игра началась. Базовое макс. здоровье: {_playerStats.GetMaxHealth()}");
        }
        else
        {
            Debug.LogError("Не удалось найти Character или CharacterData!");
        }
    }

    void Update()
    {
        // Имитируем получение навыка во время игровой сессии по нажатию клавиши Q
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (_playerStats != null)
            {
                // МАГИЯ ДЕКОРАТОРА: Берем текущие статы, оборачиваем их в новый навык 
                // и сохраняем обратно в ту же переменную!
                _playerStats = new HealthBoostSkill(_playerStats, 25f);
                
                Debug.Log($"[Декоратор] Изучен навык на +25 ХП! Теперь макс. здоровье: {_playerStats.GetMaxHealth()}");
            }
        }
    }
}