namespace TicTacToeServer
{
    partial class ServerForm
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerForm));
            connectImage = new PictureBox();
            label1 = new Label();
            gameField = new TableLayoutPanel();
            pb9 = new PictureBox();
            pb8 = new PictureBox();
            pb7 = new PictureBox();
            pb6 = new PictureBox();
            pb5 = new PictureBox();
            pb4 = new PictureBox();
            pb3 = new PictureBox();
            pb1 = new PictureBox();
            pb2 = new PictureBox();
            crossButton = new Button();
            naughtButton = new Button();
            startButton = new Button();
            resetButton = new Button();
            ((System.ComponentModel.ISupportInitialize)connectImage).BeginInit();
            gameField.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb2).BeginInit();
            SuspendLayout();
            // 
            // connectImage
            // 
            connectImage.BackColor = Color.Lime;
            connectImage.Location = new Point(95, 20);
            connectImage.Name = "connectImage";
            connectImage.Size = new Size(20, 20);
            connectImage.TabIndex = 5;
            connectImage.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(84, 20);
            label1.TabIndex = 4;
            label1.Text = "Connection";
            // 
            // gameField
            // 
            gameField.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gameField.BackgroundImageLayout = ImageLayout.None;
            gameField.CellBorderStyle = TableLayoutPanelCellBorderStyle.InsetDouble;
            gameField.ColumnCount = 3;
            gameField.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            gameField.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            gameField.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            gameField.Controls.Add(pb9, 2, 2);
            gameField.Controls.Add(pb8, 1, 2);
            gameField.Controls.Add(pb7, 0, 2);
            gameField.Controls.Add(pb6, 2, 1);
            gameField.Controls.Add(pb5, 1, 1);
            gameField.Controls.Add(pb4, 0, 1);
            gameField.Controls.Add(pb3, 2, 0);
            gameField.Controls.Add(pb1, 0, 0);
            gameField.Controls.Add(pb2, 1, 0);
            gameField.Enabled = false;
            gameField.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            gameField.ImeMode = ImeMode.Off;
            gameField.Location = new Point(12, 54);
            gameField.Name = "gameField";
            gameField.RowCount = 3;
            gameField.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            gameField.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            gameField.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            gameField.Size = new Size(591, 592);
            gameField.TabIndex = 3;
            // 
            // pb9
            // 
            pb9.BackColor = Color.White;
            pb9.BackgroundImageLayout = ImageLayout.None;
            pb9.Dock = DockStyle.Fill;
            pb9.Location = new Point(397, 398);
            pb9.Name = "pb9";
            pb9.Size = new Size(188, 188);
            pb9.SizeMode = PictureBoxSizeMode.StretchImage;
            pb9.TabIndex = 8;
            pb9.TabStop = false;
            pb9.Click += pictureBox_Click;
            // 
            // pb8
            // 
            pb8.BackColor = Color.White;
            pb8.BackgroundImageLayout = ImageLayout.None;
            pb8.Dock = DockStyle.Fill;
            pb8.Location = new Point(201, 398);
            pb8.Name = "pb8";
            pb8.Size = new Size(187, 188);
            pb8.SizeMode = PictureBoxSizeMode.StretchImage;
            pb8.TabIndex = 7;
            pb8.TabStop = false;
            pb8.Click += pictureBox_Click;
            // 
            // pb7
            // 
            pb7.BackColor = Color.White;
            pb7.BackgroundImageLayout = ImageLayout.None;
            pb7.Dock = DockStyle.Fill;
            pb7.Location = new Point(6, 398);
            pb7.Name = "pb7";
            pb7.Size = new Size(186, 188);
            pb7.SizeMode = PictureBoxSizeMode.StretchImage;
            pb7.TabIndex = 6;
            pb7.TabStop = false;
            pb7.Click += pictureBox_Click;
            // 
            // pb6
            // 
            pb6.BackColor = Color.White;
            pb6.BackgroundImageLayout = ImageLayout.None;
            pb6.Dock = DockStyle.Fill;
            pb6.Location = new Point(397, 202);
            pb6.Name = "pb6";
            pb6.Size = new Size(188, 187);
            pb6.SizeMode = PictureBoxSizeMode.StretchImage;
            pb6.TabIndex = 5;
            pb6.TabStop = false;
            pb6.Click += pictureBox_Click;
            // 
            // pb5
            // 
            pb5.BackColor = Color.White;
            pb5.BackgroundImageLayout = ImageLayout.None;
            pb5.Dock = DockStyle.Fill;
            pb5.Location = new Point(201, 202);
            pb5.Name = "pb5";
            pb5.Size = new Size(187, 187);
            pb5.SizeMode = PictureBoxSizeMode.StretchImage;
            pb5.TabIndex = 4;
            pb5.TabStop = false;
            pb5.Click += pictureBox_Click;
            // 
            // pb4
            // 
            pb4.BackColor = Color.White;
            pb4.BackgroundImageLayout = ImageLayout.None;
            pb4.Dock = DockStyle.Fill;
            pb4.Location = new Point(6, 202);
            pb4.Name = "pb4";
            pb4.Size = new Size(186, 187);
            pb4.SizeMode = PictureBoxSizeMode.StretchImage;
            pb4.TabIndex = 3;
            pb4.TabStop = false;
            pb4.Click += pictureBox_Click;
            // 
            // pb3
            // 
            pb3.BackColor = Color.White;
            pb3.BackgroundImageLayout = ImageLayout.None;
            pb3.Dock = DockStyle.Fill;
            pb3.Location = new Point(397, 6);
            pb3.Name = "pb3";
            pb3.Size = new Size(188, 187);
            pb3.SizeMode = PictureBoxSizeMode.StretchImage;
            pb3.TabIndex = 2;
            pb3.TabStop = false;
            pb3.Click += pictureBox_Click;
            // 
            // pb1
            // 
            pb1.BackColor = Color.White;
            pb1.BackgroundImageLayout = ImageLayout.None;
            pb1.Dock = DockStyle.Fill;
            pb1.Location = new Point(6, 6);
            pb1.Name = "pb1";
            pb1.Size = new Size(186, 187);
            pb1.SizeMode = PictureBoxSizeMode.StretchImage;
            pb1.TabIndex = 1;
            pb1.TabStop = false;
            pb1.Click += pictureBox_Click;
            // 
            // pb2
            // 
            pb2.BackColor = Color.White;
            pb2.BackgroundImageLayout = ImageLayout.None;
            pb2.Dock = DockStyle.Fill;
            pb2.Location = new Point(201, 6);
            pb2.Name = "pb2";
            pb2.Size = new Size(187, 187);
            pb2.SizeMode = PictureBoxSizeMode.StretchImage;
            pb2.TabIndex = 0;
            pb2.TabStop = false;
            pb2.Click += pictureBox_Click;
            // 
            // crossButton
            // 
            crossButton.BackgroundImage = (Image)resources.GetObject("crossButton.BackgroundImage");
            crossButton.BackgroundImageLayout = ImageLayout.Stretch;
            crossButton.Location = new Point(163, 8);
            crossButton.Name = "crossButton";
            crossButton.Size = new Size(40, 40);
            crossButton.TabIndex = 6;
            crossButton.TextImageRelation = TextImageRelation.TextAboveImage;
            crossButton.UseVisualStyleBackColor = true;
            crossButton.Click += crossSignButton_Click;
            // 
            // naughtButton
            // 
            naughtButton.BackgroundImage = (Image)resources.GetObject("naughtButton.BackgroundImage");
            naughtButton.BackgroundImageLayout = ImageLayout.Stretch;
            naughtButton.Location = new Point(213, 8);
            naughtButton.Name = "naughtButton";
            naughtButton.Size = new Size(40, 40);
            naughtButton.TabIndex = 7;
            naughtButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            naughtButton.UseVisualStyleBackColor = true;
            naughtButton.Click += naughtSignButton_Click;
            // 
            // startButton
            // 
            startButton.Location = new Point(303, 14);
            startButton.Name = "startButton";
            startButton.Size = new Size(94, 29);
            startButton.TabIndex = 8;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // resetButton
            // 
            resetButton.Location = new Point(406, 14);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(94, 29);
            resetButton.TabIndex = 9;
            resetButton.Text = "Reset";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += resetButton_Click;
            // 
            // ServerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(612, 653);
            Controls.Add(resetButton);
            Controls.Add(startButton);
            Controls.Add(naughtButton);
            Controls.Add(crossButton);
            Controls.Add(connectImage);
            Controls.Add(label1);
            Controls.Add(gameField);
            Name = "ServerForm";
            Text = "TicTacToe";
            ((System.ComponentModel.ISupportInitialize)connectImage).EndInit();
            gameField.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pb9).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox connectImage;
        private Label label1;
        private TableLayoutPanel gameField;
        private PictureBox pb9;
        private PictureBox pb8;
        private PictureBox pb7;
        private PictureBox pb6;
        private PictureBox pb5;
        private PictureBox pb4;
        private PictureBox pb3;
        private PictureBox pb1;
        private PictureBox pb2;
        private Button crossButton;
        private Button naughtButton;
        private Button startButton;
        private Button resetButton;
    }
}