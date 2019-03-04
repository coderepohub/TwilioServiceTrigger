using System.Web.Http;
using TwillioServices.Interfaces;

namespace TwillioServices.Controllers
{
    public class DietPlanController : ApiController
    {
        private IPlanTriggerLogic _planTriggerLogic;

        #region ctor
        public DietPlanController(IPlanTriggerLogic planTriggerLogic)
        {
            _planTriggerLogic = planTriggerLogic;
        }
        #endregion

        #region Get Calls

        /// <summary>
        /// Trigger the plan to get the Plan from Db based on Current DateTime
        /// and send SMS to Recipent
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult TriggerPlan()
        {
            var response = _planTriggerLogic.TriggerPlan();
            if (response)
                return Ok("Sucessfully Triggered!!!");
            else
                return BadRequest();
        }

        /// <summary>
        /// Get All Data from DataBase 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/DietPlan/GetAllData")]
        public IHttpActionResult GetAllData()
        {
            var getAllData = _planTriggerLogic.GetDropDownData();
            if (getAllData != null)
                return Ok(getAllData);
            else
                return BadRequest();
        }

        /// <summary>
        /// Get Plan Based on the Id (Plan Day-Time in hour)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/DietPlan/GetPlan")]
        public IHttpActionResult GetPlan(string id)
        {
            var getPlanDetailsOnId = _planTriggerLogic.GetPlan(id);
            if (getPlanDetailsOnId != null)
            {
                return Ok(getPlanDetailsOnId);
            }
            else
                return BadRequest();
        }
        #endregion

        #region Post Calls

        /// <summary>
        /// Update the DataBase(Plan) 
        /// </summary>
        /// <param name="chart"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/DietPlan/UpdatePlan")]
        public IHttpActionResult UpdatePlan([FromBody] Chart chart)
        {
            var result = _planTriggerLogic.UpSertPlan(chart);

            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        #endregion
    }
}
