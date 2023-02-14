using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform startBulletPositionLeft;
    [SerializeField] private Transform startBulletPositionRight;

    private Rigidbody rb;
    private ParticleSystem[] bulletStartParticleSystem;
    private CharacterMovement characterMovement;
    private InputController inputController;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        bulletStartParticleSystem = GetComponentsInChildren<ParticleSystem>();
        

        inputController = new InputController();
        characterMovement = new CharacterMovement(transform, rb);

        Observer.TakingDamage += GetDamage;
        
        
    }
    void Update()
    {
        characterMovement.Move();
        Shooting();
    }

    /// <summary>
    /// Активация стрельбы.
    /// </summary>
    private void Shooting()
    {
        if (inputController.GetFireButtonFirst())
            new CharacterShooting(startBulletPositionLeft, startBulletPositionRight, bulletStartParticleSystem);
    }

    private void GetDamage(int damage)
    {

        Debug.Log($"Получен урон {damage}");
        CharacterAttributes.defense -= damage;
        Debug.Log($"Текущая защита {CharacterAttributes.defense}");


    }

    private void OnDestroy()
    {
        Observer.TakingDamage -= GetDamage;
    }

}
