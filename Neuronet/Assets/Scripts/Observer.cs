using System;

/// <summary>
/// Здесь находятся все делегаты-наблюдатели.
/// </summary>
internal struct Observer
{
    /// <summary>
    /// Наблюдатель. Отслеживает момент контакта персонажа с объектом, который наносит ему урон.
    /// </summary>
    internal static Action<int> DamageReceived;

    /// <summary>
    /// Наблюдатель. Отслеживает получение опыта.
    /// </summary>
    internal static Action<int> ExperienceReceived;

    /// <summary>
    /// Наблюдатель. Отслеживает ситуации, требующие обновления данных UI.
    /// </summary>
    internal static Action UIDataUpdate;
}