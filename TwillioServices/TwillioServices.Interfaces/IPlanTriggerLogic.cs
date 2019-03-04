using System.Collections.Generic;

namespace TwillioServices.Interfaces
{
    public interface IPlanTriggerLogic
    {
        bool TriggerPlan();

        List<Chart> GetDropDownData();

        Chart GetPlan(string id);

        bool UpSertPlan(Chart chart);
    }
}
