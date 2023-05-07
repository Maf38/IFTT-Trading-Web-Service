namespace IFTT_Trading.Models.IFTT
{
    public class AlwaysTrueCondition : ICondition
    {
        public string Type => "AlwaysTrue";

        public bool isConditionOK()
        {
            return true;
        }

      
    }
}
