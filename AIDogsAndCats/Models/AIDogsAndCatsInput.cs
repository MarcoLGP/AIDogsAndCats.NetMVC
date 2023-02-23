namespace AIDogsAndCats.Models
{
    public class AIDogsAndCatsMlModel
    {
        public string? Result { get; set; }
        public decimal? Score { get; set; }

        public void GetPredict(byte[] file)
        {
            var sampleData = new AICatsAndDogsModel.ModelInput()
            {
                ImageSource = file
            };

            var output = AICatsAndDogsModel.Predict(sampleData);
            var result = output.PredictedLabel;
            Console.WriteLine(result);

        }
    }
}
