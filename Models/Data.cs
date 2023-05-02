namespace IFTT_Trading.Models
{
    //Permet de modeliser les données renvoyées par l'API REST
    public class Data
    {

        public LimitOrder LimitOrder { get; set; }
        public string Message { get; set; }

        public string Error { get; set; }
    }
}
