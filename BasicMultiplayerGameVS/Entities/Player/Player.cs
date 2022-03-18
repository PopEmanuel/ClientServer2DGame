using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicMultiplayerGameVS.Enums;

namespace BasicMultiplayerGameVS.Entities.Player
{
    internal abstract class Player : IPlayer
    {
        protected int _id;

        protected myShapes _shapeType;

        protected int _health;

        public const int _maxMovement = 10;

        protected string _name;


        public int Id { get { return this._id; }}
        public myShapes shapeType { get {return this._shapeType; } }
        public int Health { get { return this._health; } set { this._health = value; } }

        public string Name { get { return this._name; } set { this._name = value; } }


        public void Kill()
        {
            this._health = 0;
        }

        virtual public void Move_x(int amount)
        {
            throw new NotImplementedException();
        }

        virtual public void Move_y(int amount)
        {
            throw new NotImplementedException();
        }
    }
}
