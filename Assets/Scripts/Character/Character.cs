using UnityEngine;

// Класс Character должен быть абстрактным, так как он является базовым
public abstract class Character : MonoBehaviour
{
    // Приватное поле для хранения данных
    private CharacterData characterData; 
    
    // Публичное свойство Data, доступное только для чтения (get)
    // Реализует требование инкапсуляции.
    public CharacterData Data => characterData; 
    
    // Свойство для хранения компонента ввода
    protected IInputReader InputReader { get; private set; }

    // --- Измененный метод Initialize ---
    // Метод теперь принимает CharacterData и IInputReader. Помечен как virtual.
    public virtual void Initialize(CharacterData data, IInputReader inputReader)
    {
        characterData = data;
        InputReader = inputReader;
        
        // Инициализируем компонент ввода, передавая ему ссылку на Character
        if (InputReader != null)
        {
            InputReader.Initialize(this); 
        }
    }
}