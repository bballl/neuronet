using UnityEngine;

/// <summary>
/// Класс отвечает за логику стрельбы.
/// </summary>
internal sealed class CharacterShooting
{
    internal CharacterShooting(Transform startBulletPositionLeft, Transform startBulletPositionRight, ParticleSystem[] bulletStartParticleSystem)
    {
        ActivateBulletStartParticleSystem(bulletStartParticleSystem);
        ShootingLogiс(startBulletPositionLeft, startBulletPositionRight);
    }
    
    /// <summary>
    /// Логика стрельбы.
    /// </summary>
    /// <param name="startBulletPositionLeft">Позиция создания пули левого орудия.</param>
    /// <param name="startBulletPositionRight">Позиция создания пули правого орудия.</param>
    private void ShootingLogiс(Transform startBulletPositionLeft, Transform startBulletPositionRight)
    {
        Object.Instantiate(Resources.Load<GameObject>("Bullet"), startBulletPositionLeft.position, startBulletPositionLeft.rotation);
        Object.Instantiate(Resources.Load<GameObject>("Bullet"), startBulletPositionRight.position, startBulletPositionRight.rotation);
    }

    /// <summary>
    /// Активация связанной с выстрелом ParticleSystem.
    /// </summary>
    private void ActivateBulletStartParticleSystem(ParticleSystem[] bulletStartParticleSystem)
    {
        foreach (var particle in bulletStartParticleSystem)
        {
            particle.Play();
        }
    }
}