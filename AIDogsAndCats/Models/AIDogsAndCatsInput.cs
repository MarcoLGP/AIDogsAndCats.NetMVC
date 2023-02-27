namespace AIDogsAndCats.Models
{
    public class AIDogsAndCatsMlModel
    {
        public string? Result { get; set; }
        public string? ImageModel { get; set; }
        public void GetPredict(byte[] file)
        {
            
            AICatsAndDogsModel.ModelInput sampleData = new()
            {
                ImageSource = file
            };

            //Load model and predict output
            var result = AICatsAndDogsModel.Predict(sampleData);
            if (result.PredictedLabel.Equals("Cachorro"))
            {
                Result = "que se trata de um Cachorro";
            }
            else if (result.PredictedLabel.Equals("Gato"))
            {
                Result = "que se trata de um Gato";
            }
            else
            {
                Result = "que não se trata de um cachorro nem gato";
            }
        }
    }
}
