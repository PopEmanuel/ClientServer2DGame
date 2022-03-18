using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicMultiplayerGameVS.Entities.Player;
using BasicMultiplayerGameVS.Entities.Room;
using BasicMultiplayerGameVS.Enums;
using BasicMultiplayerGameVS.Exceptions;

namespace BasicMultiplayerGameVS.Repository
{
    internal class Repo
    {
        private List<Player> players;
        private List<Room> rooms;
        private int _currentRoomId;
        private int _currentPlayerId;
        private Form1 _parentForm;

        enum movement
        {
            Up,
            Down,
            Left,
            Right
        }

        public Repo(Form1 parent)
        {
            players = new List<Player>();
            rooms = new List<Room>();
            _currentRoomId = 0;
            _currentPlayerId = 0;
            this._parentForm = parent;
        }

        public int CurrentRoomId { get; set; }
        public int CurrentPlayerId { get; set;}

        public Player[] Players { get; }

        public Room[] Rooms { get; }


        public void addRoom(int id, string name, string imagePath, Size size)
        {
            if (id <= 0 || isRoomIdDefined(id))
                throw new InvalidMovementException("Room id is already defined or it's negative");
            if (isRoomNameDefined(name))
                throw new InvalidNameException("Room name is already defined");
            if (!File.Exists(imagePath))
                throw new InvalidImageException("Image path doesn't exist");

            
            Room room1 = new Room(id, name, imagePath, size, _parentForm);
            System.Diagnostics.Debug.WriteLine("CREATED ROOM ID IS : " + room1.Id + " " + id);
            room1.Paint += paintingRoom;
            room1.Click += Room1_Click;
            room1.PreviewKeyDown += Room1_PreviewKeyDown;
            System.Diagnostics.Debug.WriteLine("Added room1");
            rooms.Add(room1);
            
        }

        private void Room1_PreviewKeyDown(object? sender, PreviewKeyDownEventArgs e)
        {
            _parentForm.label1.Text = "Key down on room";
        }

        private void Room1_Click(object? sender, EventArgs e)
        {
            _parentForm.label1.Text = "ROOM CLICKED";

        }

        public void paintingRoom(object sender, PaintEventArgs e)
        {
            _parentForm.label1.Text = "paintroom";
            for(int i = 0; i < players.Count; ++i)
            {
                SquarePlayer p = (SquarePlayer)players[i];
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(255, 255, 255, 255)), p.Shape);
            }
             


        }//TODO

        public void addPlayer(int id, string name, Size size, Point coords, myShapes shape)
        {
            if (id <= 0 || isPlayerIdDefined(id))
                throw new InvalidMovementException("Player id is already defined or it's negative");
            if (isPlayerNameDefined(name))
                throw new InvalidNameException("Player name is already defined");
            Player player1;

            if (shape == myShapes.Square)
                player1 = new SquarePlayer(id, name, size, coords);
            else
                throw new InvalidShapeException("Given shape is not valid");

            players.Add(player1);
        }

        public bool isPlayerIdDefined(int id)
        {
            foreach (Player player in players)
                if (player.Id == id)
                    return true;

            return false;
        }

        public bool isRoomIdDefined(int id)
        {
            System.Diagnostics.Debug.WriteLine("Number of rooms : ");
            System.Diagnostics.Debug.WriteLine(rooms.Count);
            foreach (Room room in rooms)
            {
                System.Diagnostics.Debug.WriteLine("Room id : ");
                System.Diagnostics.Debug.WriteLine(room.Id);
                if (room.Id == id)
                {

                    return true;
                }
            }
                
                    

            return false;
        }

        public bool isPlayerNameDefined(string name)
        {
            foreach (Player player in players)
                if (player.Name == name)
                    return true;

            return false;
        }

        public bool isRoomNameDefined(string name)
        {
            foreach (Room room in rooms)
                if (room.RoomName == name)
                    return true;

            return false;
        }

        public void movePlayerX(int id, Movement mv)
        {
            if (!isPlayerIdDefined(id))
                throw new InvalidIdException("Id is not defined, can't move player");

            Player player = getPlayerById(id);
            if (mv == Movement.Left)
                player.Move_x(Player._maxMovement);
            if (mv == Movement.Right)
                player.Move_x(-Player._maxMovement);

        }

        public void movePlayerY(int id, Movement mv)
        {
            if (!isPlayerIdDefined(id))
                throw new InvalidIdException("Id is not defined, can't move player");

            Player player = getPlayerById(id);
            if(mv == Movement.Up)
                player.Move_y(-Player._maxMovement);
            if(mv == Movement.Down)
                player.Move_y(Player._maxMovement);
        }

        public Player getPlayerById(int id)
        {
            if (!isPlayerIdDefined(id))
                throw new InvalidIdException("Player id is not defined");

            foreach (Player player in players)
                if (player.Id == id)
                    return player;

            return null;
        }

        public Room getRoomById(int id)
        {
            if (!isRoomIdDefined(id))
                throw new InvalidIdException("Room id is not defined");

            foreach (Room room in rooms)
                if (room.Id == id)
                    return room;

            return null;
        }

        public void InvalidateRoom()
        {
            if (!isRoomIdDefined(CurrentRoomId))
                throw new InvalidIdException("Room id doesn't exist");
            _parentForm.label1.Text = "here";
            getRoomById(CurrentRoomId).Invalidate();
        }
    }
}
