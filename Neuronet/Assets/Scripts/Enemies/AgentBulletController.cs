using UnityEngine;

public class AgentBulletController : MonoBehaviour
{
    private void Start()
    {
        float speed = Data.AgentBulletSpeed;
        var rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int damage = Data.AgentBulletDefaultDamage;
            Observer.DamageReceivedEvent.Invoke(damage);
        }

        ActivateDestroyParticleSystem();
        Destroy(gameObject);
    }

    /// <summary>
    /// Активация эффекта взрыва.
    /// </summary>
    private void ActivateDestroyParticleSystem()
    {
        var ps = GameObject.Instantiate(Resources.Load<ParticleSystem>("AgentBulletDestroyParticleSystem"), transform.position, Quaternion.identity);
        ps.Play();
    }
}
