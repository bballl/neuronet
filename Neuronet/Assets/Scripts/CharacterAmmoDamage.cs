internal static class CharacterAmmoDamage
{
    private static int currentDamageValue = Data.BulletDefaultDamage;

    internal static int GetDamage()
    {
        return currentDamageValue;
    }
}