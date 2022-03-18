
using BasicMultiplayerGameVS.Entities.Player;
using BasicMultiplayerGameVS.Enums;

namespace BasicMultiplayerGameVS
{
    partial class Form1
    {
        



        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        /// 
        private void InitializeService()
        {
            service = new Controller.Service(this);
            service.addPlayer(1, "ema", new Size(100, 100), new Point(50, 50), Enums.myShapes.Square);
            service.addPlayer(2, "tutu", new Size(100, 100), new Point(300, 300), Enums.myShapes.Square);
            string directory = System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString();
            directory = directory + @"\Images\";

            System.Diagnostics.Debug.WriteLine(directory);
            service.addRoom(1, "room1", directory + "Room1.jpg", this.Size);
            service.CurrentPlayerId = 1;
            service.CurrentRoomId = 1;


        }
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1059, 498);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(1200, 800);
            this.MinimumSize = new System.Drawing.Size(1200, 800);
            this.Name = "Form1";
            this.Text = "BasicMultiplayerGame";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        protected override void OnKeyDown(KeyEventArgs e) 
        {
            if (e.KeyCode == Keys.D)
            {
                service.movePlayerX(service.CurrentPlayerId, Movement.Left);
            }

            if (e.KeyCode == Keys.A)
            {
                service.movePlayerX(service.CurrentPlayerId, Movement.Right);
            }

            if (e.KeyCode == Keys.W)
            {
                service.movePlayerY(service.CurrentPlayerId, Movement.Up);

            }

            if (e.KeyCode == Keys.S)
            {
                service.movePlayerY(service.CurrentPlayerId, Movement.Down);

            }

            service.InvalidateRoom();
        }

        

        #endregion

        public Label label1;
    }
}