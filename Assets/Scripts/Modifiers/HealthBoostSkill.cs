// Наследуемся от нашего базового декоратора
public class HealthBoostSkill : StatsDecorator
{
    // Здесь мы будем хранить размер бонуса (например, +50 к здоровью)
    private float _healthBonus;

    // Конструктор. Обратите внимание на ": base(providerToWrap)". 
    // Этим мы передаем "внутреннюю матрешку" в базовый класс StatsDecorator, 
    // чтобы он знал, кого оборачивает. А бонус сохраняем в этом классе.
    public HealthBoostSkill(IStatsProvider providerToWrap, float bonusAmount) : base(providerToWrap)
    {
        _healthBonus = bonusAmount;
    }

    // Переопределяем (override) метод получения здоровья
    public override float GetMaxHealth()
    {
        // 1. Спрашиваем здоровье у предыдущего слоя (у базовых статов или предыдущего баффа)
        float baseHealth = base.GetMaxHealth();
        
        // 2. Прибавляем наш бонус и отдаем итоговое значение
        return baseHealth + _healthBonus;
    }
}