using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nhsneuro.Controllers
{
    using System.Web.Http.Cors;

    using Models;

    [EnableCors("*", "*", "*")]
    public class BackendController : ApiController
    {
        private nhsneuroEntities dbContext;

        public BackendController()
        {
            dbContext = new nhsneuroEntities();
        }

        [HttpGet]
        [Route("api/helloworld")]
        public string HelloWorld()
        {
            return "Hello world!";
        }

        [HttpGet]
        [Route("api/Symptoms/")]
        public IEnumerable<SymptomModel> GetSymptoms()
        {
            return dbContext.Symptoms.Select(symptom => new SymptomModel()
            {
                Name = symptom.Name,
                Description = symptom.Description,
                SnoMedId = symptom.SnoMedId,
                SymptomId = symptom.SymptomID
            });
        }
    }
}
