using System;

/// <summary>
/// Здесь находятся все делегаты-наблюдатели.
/// </summary>
internal struct Observer
{
    /// <summary>
    /// Наблюдатель. Отслеживает момент контакта персонажа с объектом, который наносит ему урон.
    /// </summary>
    internal static Action<int> TakingDamage;
}