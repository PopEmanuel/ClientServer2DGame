using BasicMultiplayerGameVS.Entities.Room;
using BasicMultiplayerGameVS.Entities.Player;
using BasicMultiplayerGameVS.Controller;
using BasicMultiplayerGameVS.Enums;

namespace BasicMultiplayerGameVS
{
    public partial class Form1 : Form
    {
        
        

        public Form1()
        {
            InitializeComponent();
            InitializeService();
            // service.addPlayer(1, "ema", new Size(100, 100), new Point(50, 50), Enums.myShapes.Square);
            // service.addPlayer(2, "tutu", new Size(100, 100), new Point(300, 300), Enums.myShapes.Square);
           
            this.KeyPreview = true;

            
           // Console.WriteLine("YES");
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == 'd')
            {
                service.movePlayerX(service.CurrentPlayerId, Movement.Left);
            }

            if (e.KeyChar == 'a')
            {
                service.movePlayerX(service.CurrentPlayerId, Movement.Right);
            }

            if (e.KeyChar == 'w')
            {
                service.movePlayerY(service.CurrentPlayerId, Movement.Up);

            }

            if (e.KeyChar == 's')
            {
                service.movePlayerY(service.CurrentPlayerId, Movement.Down);

            }

            

            //service.InvalidateRoom();
        }

        private void startGame()
        {
            
            start = true;
            this.lblIp.Hide();
            this.btnClient.Hide();
            this.btnServer.Hide();
            this.txtIp.Hide();

            service.start();
        }

        private void btnServer_Click(object sender, EventArgs e)
        {

            if (service.createServer(txtIp.Text.ToString()))
                startGame();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {

            if(service.createClient(txtIp.Text.ToString()))
            {
                startGame();
            }
        }
    }
}