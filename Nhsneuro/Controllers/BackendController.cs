namespace Nhsneuro.Controllers
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
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
            var result = from condition in dbContext.Conditions
                join conditionSymptom in dbContext.ConditionSymptoms on condition.ConditionID equals
                    conditionSymptom.ConditionID into conditionSymptoms
                select new ConditionModel()
                {
                    Description = condition.Description,
                    IsRare = condition.IsRare,
                    Name = condition.Name,
                    SnoMedID = condition.SnoMedId,
                    Symptoms = conditionSymptoms.Select(x => x.Symptom.Name)
                };
            return result;
        }

        [HttpGet]
        [Route("api/Conditions/{symptomIds}")]
        public IEnumerable<ConditionModel> GetConditions(string symptomIds)
        {
            var listOfSymptomIdStrings = symptomIds.Split(',').Select(str => str.Trim());
            var listOfSymptomIdInts = listOfSymptomIdStrings.Select(str => Convert.ToInt32(str));
            var result = from condition in dbContext.Conditions
                join conditionSymptom in dbContext.ConditionSymptoms on condition.ConditionID equals
                    conditionSymptom.ConditionID into conditionSymptoms
                         where conditionSymptoms.Any(x => listOfSymptomIdInts.Contains(x.SymptomID))
                orderby conditionSymptoms.Count(cs => listOfSymptomIdInts.Contains(cs.SymptomID )) descending 
                select new ConditionModel()
                {
                    Description = condition.Description,
                    IsRare = condition.IsRare,
                    Name = condition.Name,
                    SnoMedID = condition.SnoMedId,
                    Symptoms = conditionSymptoms.Select(x => x.Symptom.Name)
                };
            return result;
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