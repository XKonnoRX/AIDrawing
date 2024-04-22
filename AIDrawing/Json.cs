using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDrawing
{
    internal class Json
    {
        public double[,] InputLayerWeights { get; set; }
        public double[,] OutputLayerWeights { get; set; }
        public double[] HiddenLayerBias {  get; set; }
        public double[] OutputLayerBias { get; set; }
    }
}
