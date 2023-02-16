using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void Start()
    {
        var rb = GetComponent<Rigidbody>();
        int speed = Data.BulletSpeed;
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ActivateParticleSystem();
        Destroy(gameObject);
    }

    private void ActivateParticleSystem()
    {
        var position = transform.position;
        var particleSystem = GameObject.Instantiate(Resources.Load<ParticleSystem>("BulletDestroyParticleSystem"), position, Quaternion.identity);
        particleSystem.Play();
    }
    
    
}
