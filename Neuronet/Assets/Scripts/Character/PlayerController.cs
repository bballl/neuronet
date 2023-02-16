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
    private AudioSource audioSource;
    private CharacterMovement characterMovement;
    private InputController inputController;
    private Regeneration regeneration;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        bulletStartParticleSystem = GetComponentsInChildren<ParticleSystem>();
        
        inputController = new InputController();
        characterMovement = new CharacterMovement(transform, rb);
        regeneration = new Regeneration();

        Observer.DamageReceivedEvent += GetDamage;
        Observer.ExperienceReceivedEvent += GetExperience;
    }
    private void Update()
    {
        characterMovement.Move(); //какой вариант лучше?
        Shooting();
    }

    private void FixedUpdate()
    {
        Regeneration();
    }

    private void OnDestroy()
    {
        Observer.DamageReceivedEvent -= GetDamage;
        Observer.ExperienceReceivedEvent -= GetExperience;
    }

    /// <summary>
    /// Активация стрельбы.
    /// </summary>
    private void Shooting()
    {
        if (inputController.GetFireButtonFirst())
        {
            new CharacterShooting(startBulletPositionLeft, startBulletPositionRight, bulletStartParticleSystem);
            audioSource.Play();
        }
            
    }

    /// <summary>
    /// Получение урона
    /// </summary>
    private void GetDamage(int damage)
    {
        CharacterAttributes.defense -= damage;
        Observer.UIDataUpdateEvent.Invoke();

        if (CharacterAttributes.defense <= 0)
            Observer.EndGameEvent.Invoke(false);
    }

    /// <summary>
    /// Получение опыта.
    /// </summary>
    private void GetExperience(int experience)
    {
        CharacterAttributes.experience += experience;
        Observer.UIDataUpdateEvent.Invoke();
    }

    /// <summary>
    /// Регенерация.
    /// </summary>
    private void Regeneration()
    {
        if (CharacterAttributes.isRegeneration)
        {
            bool result = regeneration.TryRegeneration(Time.deltaTime);
            if (result)
            {
                CharacterAttributes.defense += Data.RegenerationValue;
                Observer.UIDataUpdateEvent.Invoke();
            }
        }
    }

    
}
