namespace RPGCombat.Domain
{
    public class Factions
    {
        private readonly HashSet<string> _factions;

        public Factions()
        {
            _factions = new();
        }

        public void Join(string faction)
        {
            _factions.Add(faction);
        }

        public void Leave(string faction)
        {
            _factions.Remove(faction);
        }

        public HashSet<string> GetFactions()
        {
            return _factions;
        }
    }
}