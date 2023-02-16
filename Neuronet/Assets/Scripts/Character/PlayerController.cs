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

        Observer.DamageReceivedEvent += GetDamage;
        Observer.ExperienceReceivedEvent += GetExperience;
    }
    void Update()
    {
        characterMovement.Move(); //какой вариант лучше?
        Shooting();
    }

    private void OnDestroy()
    {
        Observer.DamageReceivedEvent -= GetDamage;
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
        CharacterCurrentAttributes.defense -= damage;
        Observer.UIDataUpdateEvent.Invoke();

        if (CharacterCurrentAttributes.defense <= 0)
            Observer.EndGameEvent.Invoke(false);
    }

    /// <summary>
    /// Получение опыта.
    /// </summary>
    private void GetExperience(int experience)
    {
        CharacterCurrentAttributes.experience += experience;
        Observer.UIDataUpdateEvent.Invoke();
    }
}
