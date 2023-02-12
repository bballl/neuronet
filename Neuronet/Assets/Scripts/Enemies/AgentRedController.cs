using UnityEngine;

public class AgentRedController : MonoBehaviour
{
    private int defense = Data.AgentRedDefense;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CharacterAmmo")
        {
            DamageCalculation();
        }
    }

    /// <summary>
    /// Расчет и применение урона.
    /// </summary>
    private void DamageCalculation()
    {
        var damage = CharacterAmmoDamage.GetDamage();
        defense -= damage;
        
        if (defense <= 0)
            Destroy(gameObject);
    }




}
