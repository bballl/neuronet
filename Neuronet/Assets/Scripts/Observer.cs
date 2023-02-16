using System;

/// <summary>
/// Здесь находятся все делегаты-наблюдатели.
/// </summary>
internal struct Observer
{
    /// <summary>
    /// Наблюдатель. Отслеживает момент контакта персонажа с объектом, который наносит ему урон.
    /// </summary>
    internal static Action<int> DamageReceivedEvent;

    /// <summary>
    /// Наблюдатель. Отслеживает получение опыта.
    /// </summary>
    internal static Action<int> ExperienceReceivedEvent;

    /// <summary>
    /// Наблюдатель. Отслеживает ситуации, требующие обновления данных UI.
    /// </summary>
    internal static Action UIDataUpdateEvent;


    /// <summary>
    /// Наблюдатель. Отслеживает момент окончания игровой сессии. Значение bool == true соответствует успешному прохождению игрового уровня.
    /// </summary>
    internal static Action<bool> EndGameEvent;
}