using System.Collections.Generic;

namespace TwillioServices.Interfaces
{
    public interface IDocumentDb
    {
        Chart GetPlanForToday(string id);
        List<Chart> GetAllData();
        bool UpSertData(Chart chart);
    }
}
