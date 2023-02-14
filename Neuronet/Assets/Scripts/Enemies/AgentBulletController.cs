using UnityEngine;

public class AgentBulletController : MonoBehaviour
{
    private float speed = Data.AgentBulletSpeed;
    private int damage = Data.AgentBulletDefaultDamage;

    private void Start()
    {
        var rb = GetComponent<Rigidbody>();
        
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Observer.TakingDamage.Invoke(damage);
        }

        Debug.Log("Контакт");
        Destroy(gameObject);
    }


}
