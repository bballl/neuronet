public class AgentLilacController : Enemy
{
    private void Start()
    {
        BasisInit();

        Speed = Data.AgentLilacSpeed;
        Defense = Data.AgentLilacDefense;
        ContactDamage = Data.AgentLilacContactDamage;
        Experience = Data.AgentLilacExperience;
    }

    private void FixedUpdate()
    {
        MoveToPlayer();
    }
}
