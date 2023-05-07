namespace IFTT_Trading.Models.IFTT
{
    public interface IIndicatorCondition : ICondition
    {
        string IndicatorType { get; }
        string IndicatorOperator { get; }        
        double IndicatorValue { get;  }
        double IndicatorThreshold { get; }

      

    }
}
