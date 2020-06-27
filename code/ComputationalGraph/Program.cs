using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ComputationalGraph
{
    public class Program
    {
        public List<NeuralNetwork> networks { get; set;}
        public String FileName { get; set; }
        public String DataSet { get; set; }
        
        public Program(String fileName, String dataBase)
        {
            FileName = fileName;
            DataSet = dataBase;
            networks = new List<NeuralNetwork>();
        }

        public void FitNeuralNetwork()
        {
            for (int j = 0; j < 6; j++)
            {
                string[] lines = File.ReadAllLines(DataSet);
                lines = lines.Skip(1).ToArray();

                List<List<double>> X = new List<List<double>>();
                List<List<double>> Y = new List<List<double>>();

                foreach (String line in lines)
                {
                    string[] tokens = line.Split(',');
                    List<double> row = new List<double>();
                    for (int i = 0; i < 20; i++)
                        row.Add(double.Parse(tokens[i]));

                    X.Add(row);

                    List<double> resultRow = new List<double>();
                    resultRow.Add(double.Parse(tokens[20 + j]));
                    Y.Add(resultRow);
                }

                NeuralNetwork network = new NeuralNetwork();
                network.Add(new NeuralLayer(20, 2, "sigmoid"));
                network.Add(new NeuralLayer(2, 1, "sigmoid"));

                network.fit(X, Y, 0.1, 0.9, 500);

                networks.Add(network);

            }

            var jsonString = JsonSerializer.Serialize(networks);
            File.WriteAllText(FileName, jsonString);
        }

        public List<double> PredictDiagnosis(List<double> vector)
        {
            var result = File.ReadAllText(FileName);
            List<double> retVal = new List<double>();
            networks = JsonSerializer.Deserialize<List<NeuralNetwork>>(result);

            foreach (NeuralNetwork nn in networks)
            {
                retVal.Add(nn.predict(vector)[0]);
            }
            return retVal;
        }
    }
}
