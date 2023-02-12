using System;
using UnityEngine;

public class SnowballController : MonoBehaviour
{
    private Rigidbody rb;
    private InputController inputController;

    //private float speed = Data.SnowballSpeed;
    //private float maxSpeed = Data.SnowballMaxSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        inputController = new InputController();

        //Observer.SpeedCapsuleContact += AccelerationBonusReceived;
        //Observer.FinishTriggerContact += Strike;
    }

    private void Update()
    {
        Movement();
        MaxSpeed();
        ActivationButtonChecking();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstracle"))
        {
            //Observer.ObstracleContact.Invoke();
            Strike();
        }
    }

    /// <summary>
    /// После получения бонуса ускорения, вызывает с задержкой метод ускорения.
    /// </summary>
    private void AccelerationBonusReceived()
    {
        float delay = 1.4f;
        Invoke("GetAcceleration", delay);
    }

    /// <summary>
    /// Получить ускорение.
    /// </summary>
    private void GetAcceleration()
    {
        //maxSpeed = maxSpeed * Data.SnowballAccelerationValue;
        rb.AddForce(rb.velocity.normalized * 3, ForceMode.Impulse);

        float delay = 7.1f;
        Invoke("ResetAcceleration", delay);
    }

    /// <summary>
    /// Отключение ускорения.
    /// </summary>
    private void ResetAcceleration()
    {
        //maxSpeed = Data.SnowballMaxSpeed;
    }

    /// <summary>
    /// Эффект взрыва ледяной сферы.
    /// </summary>
    private void Strike()
    {
        var position = gameObject.transform.position;
        var particleSystem = UnityEngine.Object.Instantiate(Resources.Load<ParticleSystem>("StrikeParticleSystem"), position, Quaternion.identity);
        particleSystem.Play();

        int delay = 2;
        Invoke("LoadEndGameMenu", delay);

        Debug.Log("LoadEndGameMenu отработал");
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Логика движения.
    /// </summary>
    private void Movement()
    {
        Vector3 movement = new Vector3(inputController.GetHorizontal(), 0, 0);
        rb.AddForce(movement * 3 * Time.deltaTime, ForceMode.VelocityChange);
    }

    /// <summary>
    /// Ограничение максимальной скорости.
    /// </summary>
    private void MaxSpeed()
    {
        //if (rb.velocity.z > maxSpeed)
        //{
        //    rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, maxSpeed);
        //}
    }

    /// <summary>
    /// Проверка нажатия кнопки активации (E).
    /// </summary>
    private void ActivationButtonChecking()
    {
        //bool result = inputController.IsActivateButtonDown();
        //if (result)
        //{
        //    Observer.ActivateButtonDown?.Invoke();
        //}
    }

    /// <summary>
    /// Загрузка сцены окончания игры.
    /// </summary>
    private void LoadEndGameMenu()
    {

        Debug.Log("Load...");
        //new ChangeScene().LoadScene((int)SceneName.EndGameMenu);
    }

    private void OnDestroy()
    {
        //Observer.SpeedCapsuleContact -= AccelerationBonusReceived;
        //Observer.FinishTriggerContact -= Strike;
    }
}
