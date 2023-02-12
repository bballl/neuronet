using UnityEngine;

public class AgentRedController : MonoBehaviour
{
    private EnemyMovement enemyMovement;
    private int defense = Data.AgentRedDefense;
    private float speed = Data.AgentRedSpeed;

    private void Start()
    {
        var rb= GetComponent<Rigidbody>();
        enemyMovement = new EnemyMovement(rb, transform, speed);
    }

    private void FixedUpdate()
    {
        enemyMovement.Move();
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
        defense -= damage;
        
        if (defense <= 0)
            Destroy(gameObject);
    }
}
