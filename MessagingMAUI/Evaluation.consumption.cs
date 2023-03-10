// This file was auto-generated by ML.NET Model Builder. 
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Reflection;

namespace MessagingMAUI
{
    public partial class Evaluation
    {
        /// <summary>
        /// model input class for Evaluation.
        /// </summary>
        #region model input class
        public class ModelInput
        {
            [ColumnName(@"Label")]
            public float Label { get; set; }

            [ColumnName(@"rev_id")]
            public float Rev_id { get; set; }

            [ColumnName(@"comment")]
            public string Comment { get; set; }

            [ColumnName(@"year")]
            public float Year { get; set; }

            [ColumnName(@"logged_in")]
            public bool Logged_in { get; set; }

            [ColumnName(@"ns")]
            public string Ns { get; set; }

            [ColumnName(@"sample")]
            public string Sample { get; set; }

            [ColumnName(@"split")]
            public string Split { get; set; }

        }

        #endregion

        /// <summary>
        /// model output class for Evaluation.
        /// </summary>
        #region model output class
        public class ModelOutput
        {
            [ColumnName(@"Label")]
            public uint Label { get; set; }

            [ColumnName(@"rev_id")]
            public float Rev_id { get; set; }

            [ColumnName(@"comment")]
            public float[] Comment { get; set; }

            [ColumnName(@"year")]
            public float Year { get; set; }

            [ColumnName(@"logged_in")]
            public bool Logged_in { get; set; }

            [ColumnName(@"ns")]
            public string Ns { get; set; }

            [ColumnName(@"sample")]
            public float[] Sample { get; set; }

            [ColumnName(@"split")]
            public string Split { get; set; }

            [ColumnName(@"Features")]
            public float[] Features { get; set; }

            [ColumnName(@"PredictedLabel")]
            public float PredictedLabel { get; set; }

            [ColumnName(@"Score")]
            public float[] Score { get; set; }

        }

        #endregion
        private static MLContext _mlContext = new MLContext();
        private static string MLNetModelPath = "Resources.Evaluation.zip";

        public static readonly Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(() => CreatePredictEngine(), true);

        /// <summary>
        /// Use this method to predict on <see cref="ModelInput"/>.
        /// </summary>
        /// <param name="input">model input.</param>
        /// <returns><seealso cref=" ModelOutput"/></returns>
        public static ModelOutput Predict(ModelInput input)
        {
            var predEngine = PredictEngine.Value;
            return predEngine.Predict(input);
        }

        private ITransformer LoadModel(string modelPath)
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;
            var resourceName = $"{typeof(MainPage).Namespace}.{modelPath}";
            Stream stream = assembly.GetManifestResourceStream(resourceName);

            return _mlContext.Model.Load(stream, out var inputSchema);
        }
        private static PredictionEngine<ModelInput, ModelOutput> CreatePredictEngine()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;
            var resourceName = $"{typeof(MainPage).Namespace}.{MLNetModelPath}";
            Stream stream = assembly.GetManifestResourceStream(resourceName);

            ITransformer mlModel = _mlContext.Model.Load(stream, out var inputSchema);
            return _mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
        }
    }
}
