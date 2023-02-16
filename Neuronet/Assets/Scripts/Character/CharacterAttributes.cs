internal static class CharacterAttributes
{
    internal static float rotationSpeed = Data.CharacterRotationSpeed;
    internal static int speed = Data.CharacterSpeed;
    internal static int defense = Data.CharacterDefense;
    internal static int damageValue = Data.BulletDefaultDamage;
    internal static int experience;
    internal static bool isRegeneration;

    static CharacterAttributes()
    {
        Observer.AbilitiyApplyEvent += AbilityApply;
    }
    
    internal static int GetDamageValue()
    {
        return damageValue;
    }

    /// <summary>
    /// Получение новой способности.
    /// </summary>
    private static void AbilityApply(AbilityType type)
    {
        switch (type)
        {
            case AbilityType.ExtraDefense:
                defense += Data.ExtraDefense;
                break;

            case AbilityType.ExtraDamage:
                damageValue += Data.ExtraDamage;
                break;

            case AbilityType.Regeneration:
                isRegeneration = true;
                break;
        }
    }

    /// <summary>
    /// Отписка от делегатов.
    /// </summary>
    internal static void Unsubscribe()
    {
        Observer.AbilitiyApplyEvent -= AbilityApply;
    }
}