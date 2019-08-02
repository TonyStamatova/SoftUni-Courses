using Contracts;

namespace FakeModels
{
    public class FakeDummy : ITarget
    {
        private const int XP_TO_GIVE_WHEN_KILLED = 10;

        public int GiveExperience()
        {
            return XP_TO_GIVE_WHEN_KILLED;
        }

        public bool IsDead()
        {
            return true;
        }

        public void TakeAttack(int attackPoints)
        {            
        }
    }
}
