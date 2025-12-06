using UnityEngine;
using System; // Для атрибута [Serializable]

// [Serializable] позволяет нам видеть и настраивать этот класс в Inspector
[Serializable]
public class CharacterData
{
    // Поля для хранения данных персонажа
    public float movementSpeed = 5f;
    public int maxHealth = 1;
    public string characterName = "BaseCharacter";

    // Конструктор для удобной инициализации
    public CharacterData(float speed, int health, string name)
    {
        movementSpeed = speed;
        maxHealth = health;
        characterName = name;
    }
}