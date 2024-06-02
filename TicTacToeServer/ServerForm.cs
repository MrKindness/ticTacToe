using TicTacToeLibrary.enums;
using TicTacToeLibrary.socket;
using Message = TicTacToeLibrary.Message;

namespace TicTacToeServer
{
    public partial class ServerForm : Form
    {
        private ServerSocketManager socketManager;
        private GameStatusEnum gameStatus;
        private SignEnum sign;
        private bool connected;

        private byte[] field = new byte[9] { 2, 2, 2, 2, 2, 2, 2, 2, 2 };
        Dictionary<string, int> dictionary = new Dictionary<string, int>{
            { "pb1", 0 }, { "pb2", 1 }, { "pb3", 2 },
            { "pb4", 3 }, { "pb5", 4 }, { "pb6", 5 },
            { "pb7", 6 }, { "pb8", 7 }, { "pb9", 8 }
        };
        Dictionary<int, PictureBox> pictureBoxDictionary;

        public ServerForm()
        {
            InitializeComponent();

            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, connectImage.Width - 2, connectImage.Height - 2);
            Region rg = new Region(gp);
            connectImage.Region = rg;

            pictureBoxDictionary = new Dictionary<int, PictureBox>();
            for (int i = 0; i < gameField.Controls.Count; i++)
            {
                PictureBox box = (PictureBox)gameField.Controls[i];
                int number = dictionary.GetValueOrDefault(box.Name);
                pictureBoxDictionary.Add(number, box);
            }

            setConnected(false);
            setSign(SignEnum.Cross);
            setGameStatus(GameStatusEnum.Idle);
            setFieldEnabled(false);

            socketManager = new ServerSocketManager();
            socketManager.conectionEstablishedEvent += connectionEstabilishedEventHandler;
            socketManager.connectionLostEvent += connectionLostEventHandler;
            socketManager.messageReceivedEvent += messageReceivedHandler;
            socketManager.start();
        }

        private void pictureBox_Click(object? sender, EventArgs e)
        {
            setFieldEnabled(false);
            PictureBox pictureBox = (PictureBox)sender;
            int cell = dictionary.GetValueOrDefault(pictureBox.Name);
            if (field[cell] == 0 || field[cell] == 1)
            {
                setFieldEnabled(true);
                return;
            }

            CommandEnum command;
            if (SignEnum.Cross.Equals(sign))
            {
                command = CommandEnum.Cross;
                pictureBox.Image = Image.FromFile(@"..\..\..\..\resources\cross.png");
                field[cell] = 1;
            }
            else
            {
                command = CommandEnum.Naught;
                pictureBox.Image = Image.FromFile(@"..\..\..\..\resources\naught.png");
                field[cell] = 0;
            }

            Message message = new Message(command, cell);
            bool result = socketManager.send(message);
            if(!result)
            {
                MessageBox.Show("Error!");
            }
            
            isGameFinished();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            Message message = new Message(CommandEnum.Start, 0);
            bool messageSent = socketManager.send(message);
            if (messageSent)
            {
                setGameStatus(GameStatusEnum.Active);
                if (SignEnum.Cross.Equals(sign))
                {
                    setFieldEnabled(true);
                }
                else
                {
                    setFieldEnabled(false);
                }
            }
            else
            {
                MessageBox.Show("Error!");
            }
        }

        private void crossSignButton_Click(object? sender, EventArgs e)
        {
            if (GameStatusEnum.Active.Equals(gameStatus))
            {
                return;
            }

            Message message = new Message(CommandEnum.Sign, 1);
            bool messageSent = socketManager.send(message);
            if (messageSent)
            {
                setSign(SignEnum.Cross);
            }
            else
            {
                MessageBox.Show("Error!");
            }
        }

        private void naughtSignButton_Click(object? sender, EventArgs e)
        {
            if(GameStatusEnum.Active.Equals(gameStatus))
            {
                return;
            }
            Message message = new Message(CommandEnum.Sign, 0);
            bool messageSent = socketManager.send(message);
            if (messageSent)
            {
                setSign(SignEnum.Naught);
            }
            else
            {
                MessageBox.Show("Error!");
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            Message message = new Message(CommandEnum.Reset, 0);
            bool messageSent = socketManager.send(message);
            if (messageSent)
            {
                setGameStatus(GameStatusEnum.Idle);
                field = new byte[9] { 2, 2, 2, 2, 2, 2, 2, 2, 2 };
                foreach(PictureBox box in pictureBoxDictionary.Values) {
                    box.Image = null;
                }
            }
            else
            {
                MessageBox.Show("Error!");
            }
        }

        private void connectionEstabilishedEventHandler()
        {
            BeginInvoke(new Action(() =>
            {
                setConnected(true);
                Message message = SignEnum.Naught.Equals(sign) ?
                    new Message(CommandEnum.Sign, 0) :
                    new Message(CommandEnum.Sign, 1);

                socketManager.send(message);
            }));
        }

        private void connectionLostEventHandler()
        {
            BeginInvoke(new Action(() =>
            {
                naughtButton.Enabled = false;
                crossButton.Enabled = false;
                setConnected(false);
                setFieldEnabled(false);
            }));
        }

        private void messageReceivedHandler(Message message)
        {
            BeginInvoke(new Action(() =>
            {
                switch (message.command)
                {
                    case CommandEnum.Cross:
                        {
                            field[message.data] = 1;
                            pictureBoxDictionary.GetValueOrDefault(message.data).Image =
                                Image.FromFile(@"..\..\..\..\resources\cross.png");

                            break;
                        }
                    case CommandEnum.Naught:
                        {
                            field[message.data] = 0;
                            pictureBoxDictionary.GetValueOrDefault(message.data).Image =
                                Image.FromFile(@"..\..\..\..\resources\naught.png");

                            break;
                        }
                }

                bool result = isGameFinished();
                if (!result)
                {
                    setFieldEnabled(true);
                }
            }));
        }

        private void setConnected(bool connected)
        {
            this.connected = connected;
            if (connected)
            {
                connectImage.BackColor = Color.Lime;
            }
            else
            {
                connectImage.BackColor = Color.Red;
            }
        }

        private void setSign(SignEnum sign)
        {
            this.sign = sign;
            if (SignEnum.Cross.Equals(sign))
            {
                crossButton.Enabled = false;
                naughtButton.Enabled = true;
            }
            else
            {
                naughtButton.Enabled = false;
                crossButton.Enabled = true;
            }
        }

        private void setGameStatus(GameStatusEnum status)
        {
            this.gameStatus = status;
            if (GameStatusEnum.Active.Equals(status))
            {
                startButton.Enabled = false;
                resetButton.Enabled = true;
            }
            else
            {
                startButton.Enabled = true;
                resetButton.Enabled = false;
            }
        }

        private void setFieldEnabled(bool enabled)
        {
            gameField.Enabled = enabled;
        }

        private bool isGameFinished()
        {
            int win = checkWin();
            if (win > -1)
            {
                if (win == 0)
                {
                    if (SignEnum.Naught.Equals(sign))
                    {
                        Message m = new Message(CommandEnum.Loss, 0);
                        socketManager.send(m);
                        MessageBox.Show("Victory!");
                    }
                    else
                    {
                        Message m = new Message(CommandEnum.Victory, 0);
                        socketManager.send(m);
                        MessageBox.Show("You Lose!");
                    }
                }
                else
                {
                    if (SignEnum.Cross.Equals(sign))
                    {
                        Message m = new Message(CommandEnum.Loss, 0);
                        socketManager.send(m);
                        MessageBox.Show("Victory!");
                    }
                    else
                    {
                        Message m = new Message(CommandEnum.Victory, 0);
                        socketManager.send(m);
                        MessageBox.Show("You Lose!");
                    }
                }
                return true;
            }
            return false;
        }

        private int checkWin()
        {
            if (field[0] == 1 && field[4] == 1 && field[8] == 1)
            {
                return 1;
            }
            if (field[0] == 0 && field[4] == 0 && field[8] == 0)
            {
                return 0;
            }

            if (field[2] == 1 && field[4] == 1 && field[6] == 1)
            {
                return 1;
            }
            if (field[2] == 0 && field[4] == 0 && field[6] == 0)
            {
                return 0;
            }

            for (int i = 0; i < 7; i += 3)
            {
                if (field[i] == 1 && field[i + 1] == 1 && field[i + 2] == 1)
                {
                    return 1;
                }

                if (field[i] == 0 && field[i + 1] == 0 && field[i + 2] == 0)
                {
                    return 0;
                }

                if (field[i / 3] == 1 && field[i / 3 + 3] == 1 && field[i / 3 + 6] == 1)
                {
                    return 1;
                }

                if (field[i / 3] == 0 && field[i / 3 + 3] == 0 && field[i / 3 + 6] == 0)
                {
                    return 0;
                }
            }

            return -1;
        }
    }
}