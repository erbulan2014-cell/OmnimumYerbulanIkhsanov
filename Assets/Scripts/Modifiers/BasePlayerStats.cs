public class BasePlayerStats : IStatsProvider
{
    // Ссылка на ваши базовые данные персонажа
    private CharacterData _baseData;

    // Конструктор: при создании этого класса мы должны передать ему CharacterData
    public BasePlayerStats(CharacterData data)
    {
        _baseData = data;
    }

    // Реализуем метод из нашего интерфейса IStatsProvider
    public float GetMaxHealth()
    {
        // Просто возвращаем базовое здоровье.
        // Так как в CharacterData у вас MaxHealth это int, оно автоматически
        // станет float (это полезно, если потом будем делать прибавки в процентах)
        return _baseData.MaxHealth;
    }
}