internal static class CharacterAmmoDamage
{
    private static int currentDamageValue = Data.BulletDefaultDamage;

    internal static int GetDamage()
    {
        return currentDamageValue;
    }

    internal static void SetDamageValue(int value)
    {
        currentDamageValue = value;
    }
}