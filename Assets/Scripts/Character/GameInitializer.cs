using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private PlayerCharacter playerCharacter;
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private int playerHealth = 3;
    [SerializeField] private float enemySpeed = 3.5f;
    [SerializeField] private int enemyHealth = 1;

    private void Awake()
    {
        // Игрок
        if (playerCharacter != null)
        {
            var pData = new CharacterData(playerSpeed, playerHealth, "Игрок");
            playerCharacter.SetData(pData);
            playerCharacter.Initialize(playerCharacter); // Один аргумент!
        }

        // Враг (тот, что уже на сцене)
        var enemy = FindObjectOfType<EnemyAI>();
        if (enemy != null)
        {
            var eData = new CharacterData(enemySpeed, enemyHealth, "Враг");
            enemy.SetData(eData);
            enemy.Initialize(enemy); // Один аргумент!
        }
    }
}