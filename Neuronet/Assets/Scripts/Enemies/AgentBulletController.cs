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
            Observer.TakingDamage.Invoke(damage);
        }

        Destroy(gameObject);
    }
}
