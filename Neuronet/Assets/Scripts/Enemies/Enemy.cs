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
        else if (collision.gameObject.CompareTag("Player"))
        {
            Observer.TakingDamage.Invoke(ContactDamage);
            Destroy(gameObject);
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
        var damage = CharacterAmmoDamage.GetDamage();
        Defense -= damage;

        if (Defense <= 0)
            Destroy(gameObject);
    }
}
