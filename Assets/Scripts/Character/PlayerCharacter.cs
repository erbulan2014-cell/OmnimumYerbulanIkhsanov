using UnityEngine;

public class PlayerCharacter : Character 
{
    // Используем Awake, чтобы инициализация произошла до первого Start()
    void Awake()
    {
        // 1. Создание данных (установка начальных значений для игрока)
        CharacterData playerData = new CharacterData(
            speed: 5f, 
            health: 3, 
            name: "Игрок"
        );

        // 2. Поиск компонента ввода (PlayerMovement)
        IInputReader playerInput = GetComponent<PlayerMovement>();
        
        // 3. Вызов Initialize родителя
        if (playerInput != null)
        {
            Initialize(playerData, playerInput);
        }
        else
        {
            Debug.LogError("Ошибка: PlayerCharacter требует компонент PlayerMovement (IInputReader)!");
        }
    }
    
    // Переопределяем Initialize, чтобы соответствовать сигнатуре родителя, хотя вызываем его сами.
    public override void Initialize(CharacterData data, IInputReader inputReader)
    {
        base.Initialize(data, inputReader);
    }
}