namespace Nhsneuro.Controllers
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;

    using Models;

    #endregion

    [EnableCors("*", "*", "*")]
    public class BackendController : ApiController
    {
        #region Constants and Fields

        private nhsneuroEntities dbContext;

        #endregion

        #region Constructors

        public BackendController()
        {
            dbContext = new nhsneuroEntities();
        }

        #endregion

        #region Public Methods

        [HttpGet]
        [Route("api/Conditions")]
        public IEnumerable<ConditionModel> GetConditions()
        {
            return dbContext.Conditions.Select(
                condition => new ConditionModel()
                {
                    Description = condition.Description,
                    IsRare = condition.IsRare,
                    Name = condition.Name,
                    SnowMedID = condition.SnoMedId,
                    Symptoms = condition.ConditionSymptoms.Any()
                        ? condition.ConditionSymptoms.Select(conditionSymptom => conditionSymptom.Symptom.Name)
                        : null
                });
        }

        [HttpGet]
        [Route("api/Condtions/{symptomIds}")]
        public IEnumerable<ConditionModel> GetConditions(string symptomIds)
        {
            var listOfSymptomIdStrings = symptomIds.Split(',').Select(str => str.Trim());
            var listOfSymptomIdInts = listOfSymptomIdStrings.Select(str => Convert.ToInt32(str));

            var results = dbContext.Conditions.Where(
                condition => condition.ConditionSymptoms.Any(
                    conditionSymptom => listOfSymptomIdInts.Contains(conditionSymptom.SymptomID))).Select(condition => new ConditionModel()
            {
                Description = condition.Description,
                IsRare = condition.IsRare,
                Name = condition.Name,
                SnowMedID = condition.SnoMedId,
                Symptoms = condition.ConditionSymptoms.Any()
                    ? condition.ConditionSymptoms.Select(conditionSymptom => conditionSymptom.Symptom.Name)
                    : null
                    });
            return results;
        }

        [HttpGet]
        [Route("api/Symptoms/")]
        public IEnumerable<SymptomModel> GetSymptoms()
        {
            return dbContext.Symptoms.Select(
                symptom => new SymptomModel()
                {
                    Name = symptom.Name,
                    Description = symptom.Description,
                    SnoMedId = symptom.SnoMedId,
                    SymptomId = symptom.SymptomID
                });
        }

        [HttpGet]
        [Route("api/helloworld")]
        public string HelloWorld()
        {
            return "Hello world!";
        }

        #endregion
    }
}