using UnityEngine;

public class PlayerCharacter : Character
{
    public override void Initialize(Character character)
    {
        base.Initialize(character);

        // Ищем компонент с правильным именем интерфейса - IInputReader
        var inputReader = GetComponent<IInputReader>();

        if (inputReader != null)
        {
            inputReader.Initialize(character);
            Debug.Log($"Игрок {character.Data.CharacterName} готов.");
        }
        else
        {
            Debug.LogError("Ошибка: Не найден компонент IInputReader!");
        }
    }
}