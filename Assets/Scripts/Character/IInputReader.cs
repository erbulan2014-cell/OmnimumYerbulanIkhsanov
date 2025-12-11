using UnityEngine;

public interface IInputReader
{
    // Свойство для получения направления движения
    Vector3 MoveDirection { get; }

    // Метод для инициализации ввода
    void Initialize(Character character);
}