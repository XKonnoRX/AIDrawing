using MathNet.Numerics.LinearAlgebra;

namespace AIDrawing
{
    class DataImporter
    {
        public static (Vector<double>[], int[]) LoadData(string csvFilePath)
        {
            
                var records = File.ReadAllLines(csvFilePath);

                var images = new List<Vector<double>>();
                var labels = new List<int>();
                
                foreach (var record in records)
                {
                var img = new List<double>();
                var im = record.Split(";")[0];
                foreach (var symbol in im.Split(","))
                    img.Add(double.Parse(symbol));
                labels.Add(int.Parse(record.Split(";")[1]));
                images.Add(Vector<double>.Build.DenseOfArray(img.ToArray()));
                }
                return (images.ToArray(), labels.ToArray());
        }
    }

}
