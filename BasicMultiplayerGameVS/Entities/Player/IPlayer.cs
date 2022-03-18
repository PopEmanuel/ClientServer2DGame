using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicMultiplayerGameVS.Enums;

namespace BasicMultiplayerGameVS.Entities.Player
{
    public interface IPlayer
    {
        public int Id { get; }
        public myShapes shapeType { get; }
        public int Health { get; set; }

        public string Name { get; set; }
        protected void Move_x(int amount);
        protected void Move_y(int amount);
        protected void Kill();
    }
}
