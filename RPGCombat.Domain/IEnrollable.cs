namespace RPGCombat.Domain
{
    public interface IEnrollable
    {

        public HashSet<string> Factions();
        public void Join(string faction);
        public void Leave(string faction);
    }
}