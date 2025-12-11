using UnityEngine;

public class PlayerMovement : MonoBehaviour, IInputReader
{
    private CharacterController characterController;
    private Character character; 
    
    public Vector3 MoveDirection { get; private set; }

    public void Initialize(Character character)
    {
        this.character = character;
        characterController = GetComponent<CharacterController>();
        
        if (characterController == null)
            Debug.LogError("Нет CharacterController!");
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 raw = new Vector3(h, 0f, v);
        MoveDirection = raw.magnitude > 1 ? raw.normalized : raw;

        if (character != null && characterController != null)
        {
            characterController.Move(MoveDirection * character.Data.MovementSpeed * Time.deltaTime);
            if (MoveDirection != Vector3.zero) transform.forward = MoveDirection;
        }
    }
}