using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicMultiplayerGameVS.Repository;
using BasicMultiplayerGameVS.Entities.Player;
using BasicMultiplayerGameVS.Exceptions;
using BasicMultiplayerGameVS.Enums;

namespace BasicMultiplayerGameVS.Controller
{
    internal class Service
    {
        private Repo _repository;
        private Form1 _parentForm;

        public int CurrentRoomId { get { return _repository.CurrentRoomId; } set { _repository.CurrentRoomId = value; } }
        public int CurrentPlayerId { get { return _repository.CurrentPlayerId; } set { _repository.CurrentPlayerId = value; } }

        public Service(Form1 parent)
        {
            _parentForm = parent;
            _repository = new Repo(_parentForm);

        }

        public Player[] getPlayers()
        {
            return _repository.Players;
        }

        public void addRoom(int id, string name, string imagePath, Size size)
        {

            try{
                _repository.addRoom(id, name, imagePath, size);
                
            }catch(Exception e)
            {
                Console.Error.WriteLine(e);
            }
            
        }

        public void addPlayer(int id, string name, Size size, Point coords, myShapes shape)
        {
            try
            {
                _repository.addPlayer(id, name, size, coords, shape);
            }catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
            
        }

        public void movePlayerX(int id, Movement mv)
        {
            try
            {
                _repository.movePlayerX(id, mv);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("moveplayerxexception");
            }
        }

        public void movePlayerY(int id, Movement mv)
        {
            try
            {
                _repository.movePlayerY(id, mv);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
        }

        public void InvalidateRoom()
        {
            try
            {
                _repository.InvalidateRoom();
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }
    }
}
