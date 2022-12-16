using RPGCombat.Domain.Characters;

namespace RPGCombat.Domain
{
    public class ActionRules
    {
        private readonly List<Faction> _factions;

        public ActionRules(List<Faction> factions)
        {
            _factions = factions;
        }

        public ActionRules()
        {
            _factions = new List<Faction>();
        }


        public bool AreAllies(Character character, Character otherCharacter)
        {
            return _factions.Any(faction => faction.AreAllies(character, otherCharacter));
        }

        public bool InRange(Position attacker, Position target, int range)
        {
            return Math.Sqrt(Math.Pow(attacker.X - target.X, 2) + Math.Pow(attacker.Y - target.Y, 2)) <=
                   range;
        }
    }
}