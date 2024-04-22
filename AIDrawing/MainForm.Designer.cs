namespace AIDrawing
{
    partial class MainForm
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
            sizeBar = new TrackBar();
            pictureBox = new PictureBox();
            guessButton = new Button();
            resultBox = new TextBox();
            clearButton = new Button();
            logbox = new TextBox();
            trainButton = new Button();
            saveButton = new Button();
            loadButton = new Button();
            chartPanel = new Panel();
            stopButton = new Button();
            dropButton = new Button();
            saveFileDialog = new SaveFileDialog();
            openFileDialog = new OpenFileDialog();
            numericHiddenLayer = new NumericUpDown();
            numericClasses = new NumericUpDown();
            numericEpochs = new NumericUpDown();
            label2 = new Label();
            numericWeight = new NumericUpDown();
            label3 = new Label();
            numericHeight = new NumericUpDown();
            label4 = new Label();
            label5 = new Label();
            numericSpeed = new NumericUpDown();
            label6 = new Label();
            validateLoadButton = new Button();
            trainLoadButton = new Button();
            label7 = new Label();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)sizeBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericHiddenLayer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericClasses).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericEpochs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericWeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericSpeed).BeginInit();
            SuspendLayout();
            // 
            // sizeBar
            // 
            sizeBar.LargeChange = 1;
            sizeBar.Location = new Point(493, 12);
            sizeBar.Minimum = 2;
            sizeBar.Name = "sizeBar";
            sizeBar.Size = new Size(244, 45);
            sizeBar.SmallChange = 10;
            sizeBar.TabIndex = 0;
            sizeBar.Value = 2;
            // 
            // pictureBox
            // 
            pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox.Dock = DockStyle.Left;
            pictureBox.Location = new Point(0, 0);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(487, 487);
            pictureBox.TabIndex = 1;
            pictureBox.TabStop = false;
            pictureBox.MouseDown += pictureBox_MouseDown;
            pictureBox.MouseMove += pictureBox_MouseMove;
            pictureBox.MouseUp += pictureBox_MouseUp;
            // 
            // guessButton
            // 
            guessButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            guessButton.Enabled = false;
            guessButton.Location = new Point(666, 419);
            guessButton.Name = "guessButton";
            guessButton.Size = new Size(70, 27);
            guessButton.TabIndex = 2;
            guessButton.Text = "Guess";
            guessButton.UseVisualStyleBackColor = true;
            guessButton.Click += guessButton_Click;
            // 
            // resultBox
            // 
            resultBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            resultBox.Location = new Point(493, 452);
            resultBox.Name = "resultBox";
            resultBox.Size = new Size(244, 23);
            resultBox.TabIndex = 3;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(667, 63);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(70, 27);
            clearButton.TabIndex = 4;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // logbox
            // 
            logbox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            logbox.Location = new Point(1286, 12);
            logbox.Multiline = true;
            logbox.Name = "logbox";
            logbox.ScrollBars = ScrollBars.Vertical;
            logbox.Size = new Size(239, 463);
            logbox.TabIndex = 5;
            // 
            // trainButton
            // 
            trainButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            trainButton.Location = new Point(512, 386);
            trainButton.Name = "trainButton";
            trainButton.Size = new Size(70, 27);
            trainButton.TabIndex = 6;
            trainButton.Text = "Train";
            trainButton.UseVisualStyleBackColor = true;
            trainButton.Click += trainButton_Click;
            // 
            // saveButton
            // 
            saveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            saveButton.Enabled = false;
            saveButton.Location = new Point(588, 386);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(70, 27);
            saveButton.TabIndex = 7;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // loadButton
            // 
            loadButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            loadButton.Location = new Point(664, 386);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(70, 27);
            loadButton.TabIndex = 8;
            loadButton.Text = "Load";
            loadButton.UseVisualStyleBackColor = true;
            loadButton.Click += loadButton_Click;
            // 
            // chartPanel
            // 
            chartPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            chartPanel.Location = new Point(743, 12);
            chartPanel.Name = "chartPanel";
            chartPanel.Size = new Size(537, 463);
            chartPanel.TabIndex = 9;
            // 
            // stopButton
            // 
            stopButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            stopButton.Enabled = false;
            stopButton.Location = new Point(512, 419);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(70, 27);
            stopButton.TabIndex = 10;
            stopButton.Text = "Stop";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // dropButton
            // 
            dropButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            dropButton.Enabled = false;
            dropButton.Location = new Point(590, 419);
            dropButton.Name = "dropButton";
            dropButton.Size = new Size(70, 27);
            dropButton.TabIndex = 11;
            dropButton.Text = "Drop";
            dropButton.UseVisualStyleBackColor = true;
            dropButton.Click += dropButton_Click;
            // 
            // saveFileDialog
            // 
            saveFileDialog.FileName = "weights.txt";
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "weights.txt";
            // 
            // numericHiddenLayer
            // 
            numericHiddenLayer.Increment = new decimal(new int[] { 32, 0, 0, 0 });
            numericHiddenLayer.Location = new Point(608, 152);
            numericHiddenLayer.Maximum = new decimal(new int[] { 1024, 0, 0, 0 });
            numericHiddenLayer.Minimum = new decimal(new int[] { 32, 0, 0, 0 });
            numericHiddenLayer.Name = "numericHiddenLayer";
            numericHiddenLayer.Size = new Size(61, 23);
            numericHiddenLayer.TabIndex = 13;
            numericHiddenLayer.Value = new decimal(new int[] { 128, 0, 0, 0 });
            // 
            // numericClasses
            // 
            numericClasses.Location = new Point(608, 181);
            numericClasses.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            numericClasses.Name = "numericClasses";
            numericClasses.Size = new Size(61, 23);
            numericClasses.TabIndex = 14;
            numericClasses.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // numericEpochs
            // 
            numericEpochs.Location = new Point(608, 210);
            numericEpochs.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericEpochs.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericEpochs.Name = "numericEpochs";
            numericEpochs.Size = new Size(61, 23);
            numericEpochs.TabIndex = 15;
            numericEpochs.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(514, 154);
            label2.Name = "label2";
            label2.Size = new Size(80, 15);
            label2.TabIndex = 16;
            label2.Text = "Hidden Layer:";
            // 
            // numericWeight
            // 
            numericWeight.Location = new Point(608, 123);
            numericWeight.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            numericWeight.Name = "numericWeight";
            numericWeight.Size = new Size(61, 23);
            numericWeight.TabIndex = 17;
            numericWeight.Value = new decimal(new int[] { 32, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(514, 125);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 18;
            label3.Text = "Image Size:";
            // 
            // numericHeight
            // 
            numericHeight.Location = new Point(675, 123);
            numericHeight.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            numericHeight.Name = "numericHeight";
            numericHeight.Size = new Size(61, 23);
            numericHeight.TabIndex = 12;
            numericHeight.Value = new decimal(new int[] { 32, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(514, 183);
            label4.Name = "label4";
            label4.Size = new Size(48, 15);
            label4.TabIndex = 19;
            label4.Text = "Classes:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(514, 212);
            label5.Name = "label5";
            label5.Size = new Size(48, 15);
            label5.TabIndex = 20;
            label5.Text = "Epochs:";
            // 
            // numericSpeed
            // 
            numericSpeed.DecimalPlaces = 2;
            numericSpeed.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numericSpeed.Location = new Point(608, 239);
            numericSpeed.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            numericSpeed.Name = "numericSpeed";
            numericSpeed.Size = new Size(61, 23);
            numericSpeed.TabIndex = 21;
            numericSpeed.Value = new decimal(new int[] { 2, 0, 0, 65536 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(514, 241);
            label6.Name = "label6";
            label6.Size = new Size(42, 15);
            label6.TabIndex = 22;
            label6.Text = "Speed:";
            // 
            // validateLoadButton
            // 
            validateLoadButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            validateLoadButton.Location = new Point(666, 318);
            validateLoadButton.Name = "validateLoadButton";
            validateLoadButton.Size = new Size(68, 27);
            validateLoadButton.TabIndex = 23;
            validateLoadButton.Text = "Validate";
            validateLoadButton.UseVisualStyleBackColor = true;
            validateLoadButton.Click += validateLoadButton_Click;
            // 
            // trainLoadButton
            // 
            trainLoadButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            trainLoadButton.Location = new Point(666, 285);
            trainLoadButton.Name = "trainLoadButton";
            trainLoadButton.Size = new Size(68, 27);
            trainLoadButton.TabIndex = 24;
            trainLoadButton.Text = "Train";
            trainLoadButton.UseVisualStyleBackColor = true;
            trainLoadButton.Click += trainLoadButton_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(514, 285);
            label7.Name = "label7";
            label7.Size = new Size(82, 15);
            label7.TabIndex = 25;
            label7.Text = "Load datasets:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(514, 351);
            label8.Name = "label8";
            label8.Size = new Size(132, 15);
            label8.TabIndex = 26;
            label8.Text = "Neural network actions:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1537, 487);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(trainLoadButton);
            Controls.Add(validateLoadButton);
            Controls.Add(label6);
            Controls.Add(numericSpeed);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(numericWeight);
            Controls.Add(label2);
            Controls.Add(numericEpochs);
            Controls.Add(numericClasses);
            Controls.Add(numericHiddenLayer);
            Controls.Add(numericHeight);
            Controls.Add(dropButton);
            Controls.Add(stopButton);
            Controls.Add(chartPanel);
            Controls.Add(loadButton);
            Controls.Add(saveButton);
            Controls.Add(trainButton);
            Controls.Add(logbox);
            Controls.Add(clearButton);
            Controls.Add(resultBox);
            Controls.Add(guessButton);
            Controls.Add(pictureBox);
            Controls.Add(sizeBar);
            Name = "MainForm";
            Text = "AIDrawer";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)sizeBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericHiddenLayer).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericClasses).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericEpochs).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericWeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericSpeed).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar sizeBar;
        private PictureBox pictureBox;
        private Button guessButton;
        private TextBox resultBox;
        private Button clearButton;
        private TextBox logbox;
        private Button trainButton;
        private Button saveButton;
        private Button loadButton;
        private Panel chartPanel;
        private Button stopButton;
        private Button dropButton;
        private SaveFileDialog saveFileDialog;
        private OpenFileDialog openFileDialog;
        private NumericUpDown numericHiddenLayer;
        private NumericUpDown numericClasses;
        private NumericUpDown numericEpochs;
        private Label label2;
        private NumericUpDown numericWeight;
        private Label label3;
        private NumericUpDown numericHeight;
        private Label label4;
        private Label label5;
        private NumericUpDown numericSpeed;
        private Label label6;
        private Button validateLoadButton;
        private Button trainLoadButton;
        private Label label7;
        private Label label8;
    }
}
