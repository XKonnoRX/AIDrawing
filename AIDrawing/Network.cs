using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Statistics;
using Newtonsoft.Json;

public class NeuralNetwork
{
    public Matrix<double> InputLayerWeights;
    public Matrix<double> OutputLayerWeights;
    public Vector<double> HiddenLayerBias;
    public Vector<double> OutputLayerBias;

    public int InputNeurons;
    public int HiddenNeurons;
    public int OutputNeurons;

    public NeuralNetwork(int inputNeurons, int hiddenNeurons, int outputNeurons)
    {
        InputNeurons = inputNeurons;
        HiddenNeurons = hiddenNeurons;
        OutputNeurons = outputNeurons;

        // Инициализация весов и смещений
        InputLayerWeights = Matrix<double>.Build.Random(HiddenNeurons, InputNeurons);
        OutputLayerWeights = Matrix<double>.Build.Random(OutputNeurons, HiddenNeurons);
        HiddenLayerBias = Vector<double>.Build.Random(HiddenNeurons);
        OutputLayerBias = Vector<double>.Build.Random(OutputNeurons);
    }
    public NeuralNetwork(int inputNeurons, int hiddenNeurons, int outputNeurons, string path)
    {
        InputNeurons = inputNeurons;
        HiddenNeurons = hiddenNeurons;
        OutputNeurons = outputNeurons;
        LoadWeights(path);
    }
    public void SaveWeights(string filePath)
    {
        try
        {
            var weightsToSave = new
            {
                InputLayerWeights = InputLayerWeights.ToRowArrays(),
                OutputLayerWeights = OutputLayerWeights.ToRowArrays(),
                HiddenLayerBias = HiddenLayerBias.ToArray(),
                OutputLayerBias = OutputLayerBias.ToArray()
            };

            string json = JsonConvert.SerializeObject(weightsToSave);
            File.WriteAllText(filePath, json);
            MessageBox.Show("Weights saved successfully.");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving weights: {ex.Message}");
        }
    }

    public void LoadWeights(string filePath)
    {
        try
        {
            string json = File.ReadAllText(filePath);
            var weights = JsonConvert.DeserializeObject<dynamic>(json);

            InputLayerWeights = Matrix<double>.Build.DenseOfRowArrays(weights.InputLayerWeights.ToObject<double[][]>());
            OutputLayerWeights = Matrix<double>.Build.DenseOfRowArrays(weights.OutputLayerWeights.ToObject<double[][]>());
            HiddenLayerBias = Vector<double>.Build.DenseOfEnumerable(weights.HiddenLayerBias.ToObject<double[]>());
            OutputLayerBias = Vector<double>.Build.DenseOfEnumerable(weights.OutputLayerBias.ToObject<double[]>());

            MessageBox.Show("Weights loaded successfully.");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading weights: {ex.Message}");
        }
    }

    public Vector<double> Sigmoid(Vector<double> x)
    {
        return x.Map(v => 1 / (1 + Math.Exp(-v)));
    }
  
    public Vector<double> FeedForward(Vector<double> input)
    {
        var hiddenLayerInputs = (InputLayerWeights * input) + HiddenLayerBias;
        var hiddenLayerOutputs = Sigmoid(hiddenLayerInputs);
        var outputLayerInputs = (OutputLayerWeights * hiddenLayerOutputs) + OutputLayerBias;
        return Sigmoid(outputLayerInputs);
    }
    public Vector<double> SigmoidDerivative(Vector<double> x)
    {
        return x.Map(v => v * (1 - v));
    }


    public double Train(Vector<double> input, Vector<double> target, double learningRate)
    {
        // Прямое распространение
        var hiddenLayerInputs = (InputLayerWeights * input) + HiddenLayerBias;
        var hiddenLayerOutputs = Sigmoid(hiddenLayerInputs);

        var outputLayerInputs = (OutputLayerWeights * hiddenLayerOutputs) + OutputLayerBias;
        var output = Sigmoid(outputLayerInputs);

        // Обратное распространение
        var outputErrors = target - output;
        var outputGradient = SigmoidDerivative(output);
        double loss = Math.Abs(outputGradient.Mean());
        outputGradient = outputGradient.PointwiseMultiply(outputErrors);
        outputGradient *= learningRate;

        var hiddenErrors = OutputLayerWeights.Transpose() * outputErrors;
        var hiddenGradient = SigmoidDerivative(hiddenLayerOutputs);
        hiddenGradient = hiddenGradient.PointwiseMultiply(hiddenErrors);
        hiddenGradient *= learningRate;

        // Обновление весов и смещений
        OutputLayerWeights += outputGradient.ToColumnMatrix() * hiddenLayerOutputs.ToRowMatrix();
        OutputLayerBias += outputGradient;
        InputLayerWeights += hiddenGradient.ToColumnMatrix() * input.ToRowMatrix();
        HiddenLayerBias += hiddenGradient;

        return loss;
    }

    public double Validate(Vector<double>[] inputs, Vector<double>[] targets)
    {
        int correct = 0;
        for (int i = 0; i < inputs.Length; i++)
        {
            var prediction = Test(inputs[i]);
            if (targets[i][prediction] == 1)
                correct++;
        }

        return (double)correct / inputs.Length;
    }
    public int Test(Vector<double> input)
    {
        var output = FeedForward(input);
        return output.MaximumIndex();
    }
}
