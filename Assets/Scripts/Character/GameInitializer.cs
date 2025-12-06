using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [Header("Персонажи для инициализации")]
    // Ссылки на базовые компоненты Character
    public Character playerCharacter;
    public Character enemyCharacter;

    [Header("Данные для Player")]
    // Поля для настройки данных игрока прямо в инспекторе
    public float playerSpeed = 5f;
    public int playerHealth = 3;

    [Header("Данные для Enemy")]
    public float enemySpeed = 3.5f;
    public int enemyHealth = 1;

    void Awake()
    {
        // Вызываем инициализацию, как только компоненты готовы
        InitializeCharacters();
    }

    private void InitializeCharacters()
    {
        // 1. Инициализация Игрока (Player)
        if (playerCharacter != null)
        {
            // Создаем новый экземпляр CharacterData для игрока
            CharacterData playerData = new CharacterData(playerSpeed, playerHealth, "Игрок");
            
            // Находим компонент ввода на игроке
            IInputReader playerInput = playerCharacter.GetComponent<IInputReader>();
            
            // Вызываем Initialize, передавая данные и ввод
            if (playerInput != null)
            {
                playerCharacter.Initialize(playerData, playerInput);
                Debug.Log($"Игрок {playerData.characterName} инициализирован.");
            }
            else
            {
                Debug.LogError("Игрок не имеет компонента IInputReader (PlayerMovement)!");
            }
        }

        // 2. Инициализация Врага (Enemy)
        if (enemyCharacter != null)
        {
            // Создаем новый экземпляр CharacterData для врага
            CharacterData enemyData = new CharacterData(enemySpeed, enemyHealth, "Враг");
            
            // Врагу не нужен ввод от игрока, но мы передаем null или DummyReader, 
            // чтобы соответствовать сигнатуре Initialize. В нашем случае просто передадим null.
            enemyCharacter.Initialize(enemyData, null);
            Debug.Log($"Враг {enemyData.characterName} инициализирован.");
        }
    }
}