namespace IFTT_Trading.Models.IFTT
{

    //Cette classe permet de déterminer si la condition est respecté pour un indicateur de type seuil (exemple: si le RSI14 est à 29 avec un seuil à 30 et l'operateur < alors la condition est respecté)
    public class ThresholdIndicatorCondition : IIndicatorCondition
    {
      

        public string Type { get => "Indicator"; }
        public string IndicatorType { get => "ThresholdIndicator";  }
        public string IndicatorOperator { get; }
        public double IndicatorValue { get;  }
        public  double IndicatorThreshold { get;  }

        public ThresholdIndicatorCondition(string indicatorOperator, double indicatorValue, double indicatorThreshold)
        {
            IndicatorOperator = indicatorOperator;
            IndicatorValue = indicatorValue;
            IndicatorThreshold = indicatorThreshold;
        }
        public bool isConditionOK()
        {
            switch (IndicatorOperator)
            {
                case ">":
                    if (IndicatorValue > IndicatorThreshold)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                   

            case "<":
                    if (IndicatorValue < IndicatorThreshold)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

            
             default:
                    if (IndicatorValue > IndicatorThreshold)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

            }
        }
    }
}
