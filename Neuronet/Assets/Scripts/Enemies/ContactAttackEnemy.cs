using UnityEngine;

public abstract class ContactAttackEnemy : MonoBehaviour
{
    protected EnemyMovement EnemyMovement;
    protected int Defense;
    protected float Speed;

    private void FixedUpdate()
    {
        EnemyMovement.Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CharacterAmmo"))
        {
            DamageCalculation();
        }
    }

    /// <summary>
    /// Расчет и применение урона.
    /// </summary>
    private void DamageCalculation()
    {
        var damage = CharacterAmmoDamage.GetDamage();
        Defense -= damage;
        
        if (Defense <= 0)
            Destroy(gameObject);
    }
}
