using HeroesAndMonsters.Common;
using HeroesAndMonsters.Data;
using HeroesAndMonsters.Data.Models;
using HeroesAndMonsters.Data.Models.Enums;
using HeroesAndMonsters.Data.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesAndMonsters.Engine
{
    public class InGame
    {
        private Direction direction;

        private Dictionary<Direction, Cell> go;

        private Hero hero;

        private Field map;

        private Monster monster;

        public InGame(Field map, Hero hero)
        {
            this.go = new Dictionary<Direction, Cell>()
            {
                {Direction.None,new Cell(0,0) },

                {Direction.Up,new Cell(0,-1) },

                {Direction.Down,new Cell(0,1) },

                 {Direction.Left,new Cell(-1,0) },

                {Direction.Right,new Cell(1,0) },

                {Direction.UpRight,new Cell(1,-1) },

                {Direction.UpLeft,new Cell(-1,-1) },

                {Direction.DownLeft,new Cell(-1,1) },

                {Direction.DownRight,new Cell(1,1) },
            };

            this.direction = Direction.None;

            this.map = map;

            this.monster = new Monster();

            this.hero = hero;
        }

        public void Run()
        {

            this.direction = Direction.None;

            Console.Clear();

            this.map.Matrix();

            Console.ReadKey(true);


        }
    }
}
