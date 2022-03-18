using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicMultiplayerGameVS.Enums;

namespace BasicMultiplayerGameVS.Entities.Player
{
    

    internal class SquarePlayer : Player
    {
        private Rectangle _rectangle;

        public SquarePlayer(int id, string name, Size size, Point coords)
        {
            this._id = id;
            this._shapeType = myShapes.Square;
            this._rectangle = new Rectangle(coords, size);
            this._name = name;
           
        }

        public Rectangle Shape { get { return this._rectangle; } }

        public override void Move_x(int amount) 
        {
            if (amount > _maxMovement || amount< -_maxMovement)
                throw new Exceptions.InvalidMovementException("Can't move more than " + _maxMovement.ToString() + " pixels at a time on X axis");

            this._rectangle.X += amount;
        }

        public override void Move_y(int amount)
        {
            if (amount > _maxMovement || amount < -_maxMovement)
                throw new Exceptions.InvalidMovementException("Can't move more than " + _maxMovement.ToString() + " pixels at a time on Y axis");

            this._rectangle.Y += amount;
        }
    }
}
