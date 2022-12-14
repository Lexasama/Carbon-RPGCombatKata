namespace RPGCombat.Domain
{
    public interface IHealable
    {
        void ReceiveHeal(decimal heal);
    }
}