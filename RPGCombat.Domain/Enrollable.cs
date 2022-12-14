namespace RPGCombat.Domain
{
    public abstract class Enrollable
    {
        public HashSet<string> Factions;

        public void Join(string faction)
        {
            Factions.Add(faction);
        }

        public void Leave(string faction)
        {
            Factions.Remove(faction);
        }
    }
}