using TicTacToeLibrary.enums;
using TicTacToeLibrary.socket;
using Message = TicTacToeLibrary.Message;

namespace TicTacToeClient
{
    public partial class ClientForm : Form
    {
        private ClientSocketManager socketManager;
        SignEnum sign;
        bool connected;

        private byte[] field = new byte[9] { 2, 2, 2, 2, 2, 2, 2, 2, 2 };
        Dictionary<string, int> dictionary = new Dictionary<string, int>{
            { "pb1", 0 }, { "pb2", 1 }, { "pb3", 2 },
            { "pb4", 3 }, { "pb5", 4 }, { "pb6", 5 },
            { "pb7", 6 }, { "pb8", 7 }, { "pb9", 8 }
        };
        Dictionary<int, PictureBox> pictureBoxDictionary;

        public ClientForm()
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
            setFieldEnabled(false);

            socketManager = new ClientSocketManager();
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
            if (SignEnum.Naught.Equals(sign))
            {
                command = CommandEnum.Naught;
                field[cell] = 0;
                pictureBoxDictionary.GetValueOrDefault(cell).Image = Image.FromFile(@"..\..\..\..\resources\naught.png");
            }
            else
            {
                command = CommandEnum.Cross;
                field[cell] = 1;
                pictureBoxDictionary.GetValueOrDefault(cell).Image = Image.FromFile(@"..\..\..\..\resources\cross.png");
            }

            Message message = new Message(command, cell);
            bool messageSent = socketManager.send(message);

            if (!messageSent)
            {
                MessageBox.Show("Error!");
            }
        }

        private void connectionEstabilishedEventHandler()
        {
            BeginInvoke(new Action(() =>
            {
                setConnected(true);
            }));
        }

        private void connectionLostEventHandler()
        {
            BeginInvoke(new Action(() =>
            {
                setConnected(false);
                naughtButton.Enabled = false;
                crossButton.Enabled = false;
            }));
        }

        private void messageReceivedHandler(Message message)
        {
            BeginInvoke(new Action(() =>
            {
                switch (message.command)
                {
                    case CommandEnum.Sign:
                        {
                            if (message.data == 1)
                            {
                                setSign(SignEnum.Naught);
                            }
                            else
                            {
                                setSign(SignEnum.Cross);
                            };
                            break;
                        }
                    case CommandEnum.Cross:
                        {
                            field[message.data] = 1;
                            pictureBoxDictionary.GetValueOrDefault(message.data).Image =
                                Image.FromFile(@"..\..\..\..\resources\cross.png");
                            setFieldEnabled(true);
                            break;
                        }
                    case CommandEnum.Naught:
                        {
                            field[message.data] = 0;
                            pictureBoxDictionary.GetValueOrDefault(message.data).Image =
                                Image.FromFile(@"..\..\..\..\resources\naught.png");
                            setFieldEnabled(true);
                            break;
                        }
                    case CommandEnum.Start:
                        {
                            if (SignEnum.Cross.Equals(sign))
                            {
                                setFieldEnabled(true);
                            }
                            break;
                        }
                    case CommandEnum.Loss:
                        {
                            setFieldEnabled(false);
                            MessageBox.Show("You Lose!");
                            break;
                        }
                    case CommandEnum.Victory:
                        {
                            setFieldEnabled(false);
                            MessageBox.Show("Victory!");
                            break;
                        }
                    case CommandEnum.Reset:
                        {
                            field = new byte[9] { 2, 2, 2, 2, 2, 2, 2, 2, 2 };
                            foreach (PictureBox box in pictureBoxDictionary.Values)
                            {
                                box.Image = null;
                            }
                            break;
                        }
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

        private void setFieldEnabled(bool enabled)
        {
            gameField.Enabled = enabled;
        }
    }
}