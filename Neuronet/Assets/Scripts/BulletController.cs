using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void Start()
    {
        var rb = GetComponent<Rigidbody>();
        int speed = Data.BulletSpeed;
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        
        //float delay = Data.BulletLifeTime;
        //Invoke("DestroyBullet", delay);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ActivateParticleSystem();
        Destroy(gameObject);
    }

    private void ActivateParticleSystem()
    {
        var position = transform.position;
        var particleSystem = Object.Instantiate(Resources.Load<ParticleSystem>("BulletDestroyParticleSystem"), position, Quaternion.identity);
        particleSystem.Play();
    }
    
    //private void DestroyBullet()
    //{
    //    Destroy(gameObject);
    //}
}