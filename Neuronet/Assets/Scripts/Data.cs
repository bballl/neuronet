/// <summary>
/// Хранит стартовые значения основных атрибутов.
/// </summary>
internal struct Data
{
    //персонаж
    public static readonly float CharacterRotationSpeed = 10f;
    public static readonly int CharacterSpeed = 5;
    public static readonly int CharacterDefense = 100;

    //оружие
    public static readonly float BulletLifeTime = 0.5f; //?
    public static readonly int BulletSpeed = 1;
    public static readonly int BulletDefaultDamage = 5;

    //противники
    public static readonly float AgentRedSpeed = 3f;
    public static readonly int AgentRedDefense = 15;
    public static readonly int AgentRedContactDamage = 2;
    public static readonly int AgentRedExperience = 1;
    
    public static readonly float AgentYellowBlueSpeed = 2f;
    public static readonly int AgentYellowBlueDefense = 50;
    public static readonly int AgentYellowBlueContactDamage = 3;
    public static readonly int AgentYellowBlueExperience = 2;

    public static readonly float AgentBlueRoseSpeed = 4f;
    public static readonly int AgentBlueRoseDefense = 10;
    public static readonly int AgentBlueRoseContactDamage = 1;
    public static readonly int AgentBlueRoseExperience = 1;

    public static readonly float AgentYellowGunnerSpeed = 12.7f;
    public static readonly int AgentYellowGunnerDefense = 25;
    public static readonly int AgentYellowGunnerContactDamage = 1;
    public static readonly int AgentYellowGunnerExperience = 3;

    public static readonly float AgentOrangewGunnerSpeed = 13.7f;
    public static readonly int AgentOrangeGunnerDefense = 15;
    public static readonly int AgentOrangewGunnerContactDamage = 1;
    public static readonly int AgentOrangewGunnerExperience = 5;

    //снаряды противников
    public static readonly int AgentBulletSpeed = 20;
    public static readonly int AgentBulletDefaultDamage = 5;
}