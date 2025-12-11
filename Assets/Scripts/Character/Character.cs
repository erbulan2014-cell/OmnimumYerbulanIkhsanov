using UnityEngine;

public abstract class Character : MonoBehaviour
{
    // Свойство для доступа к данным
    public CharacterData Data { get; protected set; }

    public void SetData(CharacterData data)
    {
        Data = data;
    }

    // ВАЖНО: Метод должен принимать (Character character), а не два аргумента!
    public virtual void Initialize(Character character)
    {
        
    }
}