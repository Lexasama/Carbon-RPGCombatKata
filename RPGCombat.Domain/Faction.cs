using RPGCombat.Domain.Characters;

namespace RPGCombat.Domain
{
    public class Faction
    {
        private readonly List<Character> _members;

        public Faction()
        {
            _members = new List<Character>();
        }

        public void Enroll(Character newMember)
        {
            _members.Add(newMember);
        }

        public void Fire(Character character)
        {
            _members.Remove(character);
        }

        public bool AreAllies(Character character, Character other)
        {
            return _members.Contains(character) && _members.Contains(other);
        }
    }
}