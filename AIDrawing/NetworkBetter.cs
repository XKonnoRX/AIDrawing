using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text.Json;
using AIDrawing;
using CsvHelper;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.Statistics;
using Newtonsoft.Json;

public class NeuralNetworkBetter
{
    public List<(Matrix<double> weights, Vector<double> bias)>  Neyrons = new List<(Matrix<double>, Vector<double>)>();

    public int[] NeyronsCount;
    public int LayersCount;

    public NeuralNetworkBetter(int[] neyrons)
    {
        NeyronsCount = neyrons;
        LayersCount = neyrons.Length-1;

        // Инициализация весов и смещений
        for (int i =1; i<neyrons.Length;i++)
            Neyrons.Add((Matrix<double>.Build.Random(NeyronsCount[i], NeyronsCount[i-1]), Vector<double>.Build.Random(neyrons[i])));
    }
    
    public Vector<double> Sigmoid(Vector<double> x)
    {
        return x.Map(v => 1 / (1 + Math.Exp(-v)));
    }

    public Vector<double> FeedForward(Vector<double> input)
    {
        Vector<double> output = input;
        for (int i = 0; i < LayersCount; i++)
        {
            output = (Neyrons[i].weights * output) + Neyrons[i].bias;
            output = Sigmoid(output);
        }    
        return output;
    }
    public Vector<double> SigmoidDerivative(Vector<double> x)
    {
        return x.Map(v => v * (1 - v));
    }

    public double Train(Vector<double> input, Vector<double> target, double learningRate)
    {
        // Прямое распространение
        List<Vector<double>> outputs = new List<Vector<double>>();
        Vector<double> output = input;
        for (int i = 0; i < LayersCount; i++)
        {
            outputs.Add(output);
            output = (Neyrons[i].weights * output) + Neyrons[i].bias;
            output = Sigmoid(output);
        }
        outputs.Add(output);
        // Обратное распространение

        var outputErrors = target - output;
        var outputGradient = SigmoidDerivative(output);
        double loss = Math.Abs(outputGradient.Mean());
        for (int i = LayersCount; i>0;i--)
        {
            if(i != LayersCount)
                outputErrors = Neyrons[i].weights.Transpose() * outputErrors;
            var gradient = SigmoidDerivative(outputs[i]);
            gradient = gradient.PointwiseMultiply(outputErrors);
            gradient*=learningRate;
            var matrix = Neyrons[i-1].weights + gradient.ToColumnMatrix() * outputs[i - 1].ToRowMatrix();
            var vector = Neyrons[i-1].bias + gradient;
            Neyrons[i-1] = (matrix, vector);
        }
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
