using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }

            GiveBonusForBeginner(attackPlayer);
            GiveBonusForBeginner(enemyPlayer);

            GetHealthPointsFromDeck(attackPlayer);
            GetHealthPointsFromDeck(enemyPlayer);

            while(!attackPlayer.IsDead && !enemyPlayer.IsDead)
            {
                int damagePoints = attackPlayer.CardRepository.Cards.Select(c => c.DamagePoints).Sum();
                enemyPlayer.TakeDamage(damagePoints);

                if (!enemyPlayer.IsDead)
                {
                    damagePoints = enemyPlayer.CardRepository.Cards.Select(c => c.DamagePoints).Sum();
                    attackPlayer.TakeDamage(damagePoints);
                }
            }
        }

        private void GetHealthPointsFromDeck(IPlayer player)
        {
            foreach (ICard card in player.CardRepository.Cards)
            {
                player.Health += card.HealthPoints;
            }
        }

        private void GiveBonusForBeginner(IPlayer player)
        {
            if (player is Beginner beginner)
            {
                beginner.Health += 40;

                foreach (ICard card in beginner.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
        }
    }
}
