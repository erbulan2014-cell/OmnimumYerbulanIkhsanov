using UnityEngine;
using System;

[Serializable]
public class CharacterData
{
    // Свойства доступны для чтения извне, но менять их может только этот класс
    [field: SerializeField] public float MovementSpeed { get; private set; }
    [field: SerializeField] public int MaxHealth { get; private set; }
    [field: SerializeField] public string CharacterName { get; private set; }

    // Конструктор для инициализации
    public CharacterData(float speed, int health, string name)
    {
        MovementSpeed = speed;
        MaxHealth = health;
        CharacterName = name;
    }
}