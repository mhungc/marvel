using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marvel.World.Models
{
    public class War
    {
        private Hero _hero { get; set; }
        private Villain _villain { get; set; }

        private FightResult _fightResult;
        public FightResult FightResult { get => _fightResult; private set => _fightResult = value; }

        private string _showResult;
        public string ShowResult { get => _showResult; private set => _showResult = value; }

        public War(Hero hero, Villain villain)
        {
            _hero = hero;
            _villain = villain;
        }

        public void Fight()
        {
            _fightResult = (_hero.PowerLevel > _villain.PowerLevel) ? FightResult.Win : FightResult.Lose;
            _showResult = _fightResult.ToString();
        }
    }
}
