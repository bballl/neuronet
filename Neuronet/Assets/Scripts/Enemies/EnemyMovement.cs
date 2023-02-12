using UnityEngine;

internal sealed class EnemyMovement
{

    private Rigidbody rb;
    private Transform enemyTransform;
    private Transform playerTransform;
    private float speed;

    internal EnemyMovement(Rigidbody rigidbody, Transform transform, float speed)
    {
        rb = rigidbody;
        enemyTransform = transform;
        this.speed = speed;

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    /// <summary>
    /// ������ ��������. ������� � ���������� ������, ������� �������� ����. 
    /// </summary>
    internal void Move()
    {
        enemyTransform.LookAt(playerTransform);
        rb.AddForce(enemyTransform.forward * Time.deltaTime * speed, ForceMode.Impulse);
    }
}
