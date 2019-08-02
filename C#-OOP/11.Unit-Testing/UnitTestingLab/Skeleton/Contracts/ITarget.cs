namespace Contracts
{
    public interface ITarget
    {
        int GiveExperience();

        bool IsDead();

        void TakeAttack(int attackPoints);
    }
}
