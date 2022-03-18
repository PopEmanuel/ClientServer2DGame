using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicMultiplayerGameVS.Entities.Room
{
    public class Room : Panel
    {
        private int _id;
        private string _roomName;
        private string _imagePath;
        private Form1 parent;

        public int Id { get { return this._id; } set { this._id = value; } }
        public string RoomName { get; set; }

        public string ImagePath { get; set; }

        public Room(int id, string name, string imagePath, Size size, Form1 parent) : base()
        {
            this._id = id;
            System.Diagnostics.Debug.WriteLine("ID GOT IS : " + id + " " + this._id + " " + this.Id);
            this._roomName = name;
            this._imagePath = imagePath;
            this.Location = new Point(0, 0);
            this.Size = size;
            this.BackColor = Color.Red;
            this.Parent = parent;
            this.parent = parent;
            this.BackgroundImage = Bitmap.FromFile(_imagePath);
            this.PreviewKeyDown += Room_PreviewKeyDown;
            //this.Paint += Room_Paint;
           
        }

        private void Room_PreviewKeyDown(object? sender, PreviewKeyDownEventArgs e)
        {
            parent.label1.Text = "keydownroom";
        }

        private void Room_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(new Pen(new SolidBrush(Color.Blue)), new Rectangle(100, 100, 100, 100));
        }

        public new bool DoubleBuffered { get { return base.DoubleBuffered; } set { base.DoubleBuffered = value; } }



   
    }
}
