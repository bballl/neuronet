using UnityEngine;

public class AgentBulletController : MonoBehaviour
{
    void Start()
    {
        var rb = GetComponent<Rigidbody>();
        float speed = 20;
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    
}
