using UnityEngine;

// Реализуем IInputReader
public class PlayerMovement : MonoBehaviour, IInputReader
{
    private CharacterController characterController;
    public float moveSpeed = 5f;
    
    // --- Реализация IInputReader ---
    // Публичное свойство для получения вектора движения
    public Vector3 MoveDirection { get; private set; }

    // Метод для инициализации ввода (требуется интерфейсом, пока не используется)
    public void Initialize(Character character)
    {
        // Здесь можно было бы настроить, какой Character управляет этим вводом.
        // Но для базового движения игрока это остается пустым.
    }
    // --- Конец реализации IInputReader ---


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        if (characterController == null)
        {
            Debug.LogError("PlayerMovement требует компонент CharacterController на объекте Player!");
        }
    }

    void Update()
    {
        // 1. Считываем ввод с клавиатуры
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Создаем вектор движения на основе ввода
        Vector3 rawMoveDirection = new Vector3(horizontalInput, 0f, verticalInput);
        
        // 2. Нормализуем и сохраняем в свойство MoveDirection
        if (rawMoveDirection.magnitude > 1)
        {
            // Используем .normalized, чтобы движение по диагонали не было быстрее
            MoveDirection = rawMoveDirection.normalized;
        }
        else
        {
            MoveDirection = rawMoveDirection;
        }

        // 3. Перемещаем персонажа
        if (characterController != null)
        {
            characterController.Move(MoveDirection * moveSpeed * Time.deltaTime);
        }
    }
}