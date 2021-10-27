using System;
using System.Collections.Generic;
using System.Text;
using VM.Models;
using VM.Services.Abstraction.Factories;
using VM.Services.Abstraction.Types;
using VM.Services.Implementation.Types;

namespace VM.Services.Implementation.Factories
{
    public class ScenarioFactory : IScenarioFactory
    {
        public IScenario GetScenario(string fileType)
        {
            IScenario scenario;

            var dicScenarioTypes = GetScenarioTypesFromDictionary();

            if (!dicScenarioTypes.TryGetValue(fileType, out scenario))
            {
                throw new NotImplementedException($"No implementation for interface {fileType}");
            }

            return scenario;
        }

        private Dictionary<string, IScenario> GetScenarioTypesFromDictionary()
        {
            return new Dictionary<string, IScenario>
            {
                {SystemConstants.FILE_TYPE_XML, new ScenarioXML()}
            };
        }
    }
}
