using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected EnemyMovement EnemyMovement;
    protected Rigidbody Rb;
    protected Transform PlayerTransform;

    protected float Speed;
    protected int Defense;
    protected int ContactDamage;
    protected int Experience;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CharacterAmmo"))
        {
            DamageCalculation();
        }
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Observer.DamageReceivedEvent.Invoke(ContactDamage);
            GameObjectDestroy();
        }
    }

    /// <summary>
    /// Базовая инициация, необходимая для всех наследников класса Enemy. Получение ссылок на свой Rigidbody и Transform игрока.
    /// </summary>
    protected void BasisInit()
    {
        Rb = GetComponent<Rigidbody>();
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    /// <summary>
    /// Логика движения к игроку. Поворот к трансформу игрока, импульс твердому телу. 
    /// </summary>
    protected void MoveToPlayer()
    {
        transform.LookAt(PlayerTransform);
        Rb.AddForce(transform.forward * Time.deltaTime * Speed, ForceMode.Impulse);
    }

    /// <summary>
    /// Расчет и применение полученного урона.
    /// </summary>
    private void DamageCalculation()
    {
        var damage = CharacterAttributes.damageValue;
        Defense -= damage;

        if (Defense <= 0)
        {
            Observer.ExperienceReceivedEvent.Invoke(Experience);
            GameObjectDestroy();
        }
    }

    /// <summary>
    /// Уничтожение агента.
    /// </summary>
    private void GameObjectDestroy()
    {
        ActivateDestroyParticleSystem();
        Destroy(gameObject);
    }
    
    /// <summary>
    /// Активация эффекта взрыва.
    /// </summary>
    private void ActivateDestroyParticleSystem()
    {
        var particleSystem = GameObject.Instantiate(Resources.Load<ParticleSystem>("AgentBulletDestroyParticleSystem"), 
            transform.position, Quaternion.identity);
        particleSystem.Play();
    }
}
