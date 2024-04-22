using MathNet.Numerics.LinearAlgebra;
using System.Windows.Forms.DataVisualization.Charting;

namespace AIDrawing
{
    public partial class MainForm : Form
    {
        private NeuralNetwork network;
        private NeuralNetworkBetter network2;
        bool mouseDown = false;
        bool training = false;
        Point pp = new Point();
        string trainingSet = "annotation.csv";
        string validationSet = "test.csv";
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var image = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
            Graphics graphics = Graphics.FromImage(image);
            graphics.Clear(Color.White);
            pictureBox.Image = image;
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private async void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                var img = pictureBox.Image;
                int size = sizeBar.Value * 2;
                Graphics graphics = Graphics.FromImage(img);
                Pen pen = new Pen(Color.Black, 2 * size);
                int steps = 100 / size;
                if (pp == new Point())
                    graphics.FillEllipse(pen.Brush, e.X - size / 2, e.Y - size / 2, size, size);
                else
                {
                    for (int i = 0; i < steps; i++)
                    {
                        int x = pp.X + ((e.X - pp.X) * i / steps);
                        int y = pp.Y + ((e.Y - pp.Y) * i / steps);
                        graphics.FillEllipse(pen.Brush, x - size / 2, y - size / 2, size, size);
                    }
                }
                pp = e.Location;
                pictureBox.Image = null;
                pictureBox.Image = img;
            }
        }

        (int, double, double)[] Train(IProgress<(int, double, double)> progress)
        {
            int pixels = (int)(numericWeight.Value * numericHeight.Value); // Размер входного слоя (1024 входа)
            int hiddenNeurons = (int)numericHiddenLayer.Value; // Число нейронов в скрытом слое
            int outputNeurons = (int)numericClasses.Value; // Количество классов (10)
            if (!saveButton.Enabled)
                network = new NeuralNetwork(pixels, hiddenNeurons, outputNeurons);

            (Vector<double>[] trainingInputs, int[] trainingLabels) = DataImporter.LoadData(trainingSet);
            Vector<double>[] trainingTargets = ConvertLabelsToOneHotVectors(trainingLabels, outputNeurons);

            (Vector<double>[] testingInputs, int[] testingLabels) = DataImporter.LoadData(validationSet);
            Vector<double>[] testingTargets = ConvertLabelsToOneHotVectors(testingLabels, outputNeurons);

            // Параметры обучения
            double learningRate = (double)numericSpeed.Value;
            int epochs = (int)numericEpochs.Value;
            var res = new List<(int, double, double)>();
            // Обучение
            for (int epoch = 0; epoch < epochs; epoch++)
            {
                if (training)
                {
                    double loss = 0;
                    for (int i = 0; i < trainingInputs.Length; i++)
                    {
                        loss += network.Train(trainingInputs[i], trainingTargets[i], learningRate);
                    }
                    double accuracy = network.Validate(testingInputs, testingTargets);
                    loss /= trainingInputs.Length;
                    progress.Report((epoch, accuracy, loss));
                    res.Add((epoch, accuracy, loss));
                }
            }
            return res.ToArray();
        }
        (int, double, double)[] Train2(IProgress<(int, double, double)> progress)
        {
            int pixels = (int)(numericWeight.Value * numericHeight.Value); // Размер входного слоя (1024 входа)
            int hiddenNeurons = (int)numericHiddenLayer.Value; // Число нейронов в скрытом слое
            int outputNeurons = (int)numericClasses.Value; // Количество классов (10)
            network2 = new NeuralNetworkBetter(new int[] { pixels, hiddenNeurons, 64, 8, outputNeurons });

            (Vector<double>[] trainingInputs, int[] trainingLabels) = DataImporter.LoadData(trainingSet);
            Vector<double>[] trainingTargets = ConvertLabelsToOneHotVectors(trainingLabels, outputNeurons);

            (Vector<double>[] testingInputs, int[] testingLabels) = DataImporter.LoadData(validationSet);
            Vector<double>[] testingTargets = ConvertLabelsToOneHotVectors(testingLabels, outputNeurons);

            // Параметры обучения
            double learningRate = (double)numericSpeed.Value;
            int epochs = (int)numericEpochs.Value;
            var res = new List<(int, double, double)>();
            // Обучение
            for (int epoch = 0; epoch < epochs; epoch++)
            {
                if (training)
                {
                    double loss = 0;
                    for (int i = 0; i < trainingInputs.Length; i++)
                    {
                        loss += network2.Train(trainingInputs[i], trainingTargets[i], learningRate);
                    }
                    double accuracy = network2.Validate(testingInputs, testingTargets);
                    loss /= trainingInputs.Length;
                    progress.Report((epoch, accuracy, loss));
                    res.Add((epoch, accuracy, loss));
                }
            }
            return res.ToArray();
        }
        static Vector<double>[] ConvertLabelsToOneHotVectors(int[] labels, int numClasses)
        {
            var targets = new Vector<double>[labels.Length];
            for (int i = 0; i < labels.Length; i++)
            {
                double[] values = new double[numClasses];
                values[labels[i]] = 1.0;
                targets[i] = Vector<double>.Build.DenseOfArray(values);
            }
            return targets;
        }
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            pp = new Point();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            var image = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
            Graphics graphics = Graphics.FromImage(image);
            graphics.Clear(Color.White);
            pictureBox.Image = image;
        }

        private void guessButton_Click(object sender, EventArgs e)
        {
            var dict = new string[] { "телец", "водолей", "рыбы", "рак", "овен", "близнецы", "стрелец", "скорпион", "лев", "весы" };
            var vect = new List<double>();
            var img = (Bitmap)pictureBox.Image;
            img = Crop();
            var bytes = BitMapToByteArray(img);
            foreach (byte b in bytes)
                vect.Add(b > 0 ? 0 : 1);
            resultBox.Text = dict[network2.Test(Vector<double>.Build.Dense(vect.ToArray()))];
        }
        private Bitmap Crop()
        {
            var img = (Bitmap)pictureBox.Image;
            int minx = img.Width;
            int miny = img.Height;
            int maxx = 0;
            int maxy = 0;
            for (int x = 0; x < img.Width; x++)
            {
                for (int y = 0; y < img.Height; y++)
                {
                    var c = img.GetPixel(x, y);
                    if (img.GetPixel(x, y).R == 0)
                    {
                        if (x < minx)
                            minx = x - 5;
                        if (x > maxx)
                            maxx = x + 5;
                        if (y < miny)
                            miny = y - 5;
                        if (y > maxy)
                            maxy = y + 5;
                    }
                }
            }
            int width = maxx - minx;
            int height = maxy - miny;
            if (width > height)
            {
                int div = width - height;
                miny -= div / 2;
                maxy += div / 2;
            }
            else
            {
                int div = height - width;
                minx -= div / 2;
                maxx += div / 2;
            }
            var buf = new Bitmap(maxx - minx, maxy - miny);
            Graphics graphics = Graphics.FromImage(buf);
            graphics.Clear(Color.White);
            for (int x = minx; x < maxx; x++)
            {
                int nx = x - minx;
                for (int y = miny; y < maxy; y++)
                {
                    int ny = y - miny;
                    if (x < img.Width && y < img.Height && x >= 0 && y >= 0)
                        if (nx < buf.Width && ny < buf.Height)
                            if (img.GetPixel(x, y).R == 0)
                                buf.SetPixel(nx, ny, Color.Black);
                }
            }
            var result = new Bitmap((int)numericWeight.Value, (int)numericHeight.Value);
            graphics = Graphics.FromImage(result);
            graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graphics.DrawImage(buf, 0, 0, (int)numericWeight.Value, (int)numericHeight.Value);
            for (int x = 0; x < result.Width; x++)
            {
                for (int y = 0; y < result.Height; y++)
                    if (result.GetPixel(x, y).R < 210)
                        result.SetPixel(x, y, Color.Black);
                    else
                        result.SetPixel(x, y, Color.White);
            }
            return result;
        }
       
        private async void trainButton_Click(object sender, EventArgs e)
        {
            training = true;
            stopButton.Enabled = true;
            chartPanel.Controls.Clear();
            Chart myChart = new Chart();
            myChart.Dock = DockStyle.Fill;
            myChart.ChartAreas.Add(new ChartArea("Math functions"));
            Series acc = new Series("accuracy");
            acc.ChartType = SeriesChartType.Line;
            acc.MarkerSize = 2;
            acc.ChartArea = "Math functions";
            acc.Color = Color.Blue;
            Series loss = new Series("loss");
            loss.ChartType = SeriesChartType.Line;
            loss.MarkerSize = 2;
            loss.ChartArea = "Math functions";
            loss.Color = Color.Red;
            myChart.Series.Add(acc);
            myChart.Series.Add(loss);
            chartPanel.Controls.Add(myChart);
            IProgress<(int, double, double)> progress = new Progress<(int, double, double)>(point =>
            {
                logbox.AppendText($"Epoch {point.Item1}, Test Accuracy: {point.Item2:P2}, Loss: {point.Item3}\r\n");
                acc.Points.AddXY(point.Item1, point.Item2);
                loss.Points.AddXY(point.Item1, point.Item3);
                logbox.AutoScrollOffset = new Point(Right, Bottom);
            });
            await Task.Run(() => Train2(progress));
            logbox.AppendText("End of training!");
            guessButton.Enabled = true;
            saveButton.Enabled = true;
            dropButton.Enabled = true;
            training = false;
            stopButton.Enabled = false;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveFileDialog.InitialDirectory = Path.GetDirectoryName(Application.StartupPath);
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog.FileName;
            network.SaveWeights(filename);
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Path.GetDirectoryName(Application.StartupPath);
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog.FileName;
            int pixels = (int)(numericWeight.Value * numericHeight.Value); // Размер входного слоя (1024 входа)
            int hiddenNeurons = (int)numericHiddenLayer.Value; // Число нейронов в скрытом слое
            int outputNeurons = (int)numericClasses.Value; // Количество классов (10)
            network = new NeuralNetwork(pixels, hiddenNeurons, outputNeurons, filename);
            guessButton.Enabled = true;
            saveButton.Enabled = true;
            dropButton.Enabled = true;
        }
        public static byte[] BitMapToByteArray(Bitmap img)
        {
            var res = new byte[img.Width * img.Height];
            for (int y = 0; y < img.Height; y++)
                for (int x = 0; x < img.Width; x++)
                    res[y * img.Width + x] = img.GetPixel(x, y).R;
            return res;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            training = false;
        }

        private void dropButton_Click(object sender, EventArgs e)
        {
            network = null;
            network2 = null;
            saveButton.Enabled=false;
            guessButton.Enabled=false;
            dropButton.Enabled=false;
        }
        private void trainLoadButton_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Path.GetDirectoryName(Application.StartupPath);
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            trainingSet = openFileDialog.FileName;
        }
        private void validateLoadButton_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Path.GetDirectoryName(Application.StartupPath);
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            validationSet = openFileDialog.FileName;
        }
    }
}
