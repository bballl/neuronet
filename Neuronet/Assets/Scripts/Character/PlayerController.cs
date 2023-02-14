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

        Observer.DamageReceived += GetDamage;
        Observer.ExperienceReceived += GetExperience;
    }
    void Update()
    {
        characterMovement.Move(); //какой вариант лучше?
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

    /// <summary>
    /// Получение урона
    /// </summary>
    private void GetDamage(int damage)
    {
        CharacterAttributes.defense -= damage;
        Observer.UIDataUpdate.Invoke();
    }

    private void GetExperience(int experience)
    {
        CharacterAttributes.experience += experience;
        Observer.UIDataUpdate.Invoke();
    }

    private void OnDestroy()
    {
        Observer.DamageReceived -= GetDamage;
    }

}
