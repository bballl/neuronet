using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected EnemyMovement EnemyMovement;
    protected Rigidbody Rb;
    protected Transform PlayerTransform;
    protected int Defense;
    protected float Speed;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CharacterAmmo"))
        {
            DamageCalculation();
        }
    }

    /// <summary>
    /// ������� ���������, ����������� ��� ���� ����������� ������ Enemy. ��������� ������ �� ���� Rigidbody � Transform ������.
    /// </summary>
    protected void BasisInit()
    {
        Rb = GetComponent<Rigidbody>();
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    

    /// <summary>
    /// ������ �������� � ������. ������� � ���������� ������, ������� �������� ����. 
    /// </summary>
    protected void MoveToPlayer()
    {
        transform.LookAt(PlayerTransform);
        Rb.AddForce(transform.forward * Time.deltaTime * Speed, ForceMode.Impulse);
    }


    /// <summary>
    /// ������ � ���������� ����������� �����.
    /// </summary>
    private void DamageCalculation()
    {
        var damage = CharacterAmmoDamage.GetDamage();
        Defense -= damage;

        if (Defense <= 0)
            Destroy(gameObject);
    }
}
