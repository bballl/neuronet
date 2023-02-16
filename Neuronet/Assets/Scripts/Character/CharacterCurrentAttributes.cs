internal static class CharacterCurrentAttributes
{
    internal static float rotationSpeed = Data.CharacterRotationSpeed;
    internal static int speed = Data.CharacterSpeed;
    internal static int defense = Data.CharacterDefense;
    internal static int damageValue = Data.BulletDefaultDamage;
    internal static int experience;

    static CharacterCurrentAttributes()
    {
        Observer.AbilitiyApplyEvent += AbilityApply;
    }
    
    internal static int GetDamageValue()
    {
        return damageValue;
    }

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