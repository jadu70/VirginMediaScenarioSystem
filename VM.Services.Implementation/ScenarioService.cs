using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using VM.Models;
using VM.Services.Abstraction;
using VM.Services.Abstraction.Factories;

namespace VM.Services.Implementation
{
    public class ScenarioService : IScenarioService
    {
        private readonly IConfiguration _configuration;
        private readonly IScenarioFactory _scenarioFactory;

        public ScenarioService(IConfiguration configuration,
                               IScenarioFactory scenarioFactory)
        {
            _configuration = configuration;
            _scenarioFactory = scenarioFactory;
        }

        public List<Scenario> ScenariosToDisplay()
        {
            string[] dataFiles = GetFilePath();

            var scenarios = new List<Scenario>();
            foreach (var dataFile in dataFiles)
            {
                string fileExt = GetFileExtension(dataFile);

                scenarios.AddRange(_scenarioFactory.GetScenario(fileExt).ProcessFile(dataFile));
            }

            return scenarios;
        }

        private static string GetFileExtension(string dataFile)
            => Path.GetExtension(dataFile).Trim('.').ToLower();
        
        private string[] GetFilePath()
        {
            var externalFileLocation = _configuration.GetValue<string>("FileLocation");

            string[] dataFiles = Directory.GetFiles(@externalFileLocation);

            return dataFiles;
        }
    }
}
