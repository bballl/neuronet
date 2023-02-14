using UnityEngine;

public class AgentBulletController : MonoBehaviour
{
    private void Start()
    {
        var rb = GetComponent<Rigidbody>();
        float speed = 20;
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CharacterAmmo"))
        {
            //DamageCalculation();

        }
    }


}
