using System;
using System.Collections.Generic;
using TwillioServices.Interfaces;

namespace TwillioServices.Logics
{
    public class PlanTriggerLogic : IPlanTriggerLogic
    {
        private IDocumentDb _documentDb;
        private ITwillioLogic _twillioLogic;


        public PlanTriggerLogic(IDocumentDb documentDb, ITwillioLogic twillioLogic)
        {
            _documentDb = documentDb;
            _twillioLogic = twillioLogic;
        }

        public List<Chart> GetDropDownData()
        {
            return _documentDb.GetAllData();
        }

        public bool TriggerPlan()
        {
            //Fetch Current Time
            TimeZoneInfo INDIAN_TIME_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime ist = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_TIME_ZONE);
            string id = string.Format($"{ist.Date.DayOfWeek.ToString().ToUpper()}-{ist.ToString("HH")}");
            var getChart = _documentDb.GetPlanForToday(id);

            CallTwillioService(getChart.plan);

            return true;
        }

        private void CallTwillioService(string plan)
        {
            _twillioLogic.SendMessageToSender(plan);
        }

        public Chart GetPlan(string id)
        {
            return _documentDb.GetPlanForToday(id);
        }

        public bool UpSertPlan(Chart chart)
        {
            return _documentDb.UpSertData(chart);
        }
    }
}
