internal static class CharacterCurrentAttributes
{
    internal static float rotationSpeed = Data.CharacterRotationSpeed;
    internal static int speed = Data.CharacterSpeed;
    internal static int defense = Data.CharacterDefense;
    internal static int experience;
    internal static int currentDamageValue = Data.BulletDefaultDamage;

    static CharacterCurrentAttributes()
    {
        Observer.CharacterExtraDefenseEvent += ExtraDefense;
    }
    
    internal static int GetDamageValue()
    {
        return currentDamageValue;
    }

    internal static void SetDamageValue(int value)
    {
        currentDamageValue = value;
    }

    private static void ExtraDefense()
    {
        defense += 100;
    }
}