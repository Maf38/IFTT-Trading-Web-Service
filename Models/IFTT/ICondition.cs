namespace IFTT_Trading.Models.IFTT
{
    public interface ICondition
    {

        string Type { get; }
        Boolean isConditionOK();

    }
}
