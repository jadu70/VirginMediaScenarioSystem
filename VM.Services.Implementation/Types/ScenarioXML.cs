using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using VM.Models;
using VM.Services.Abstraction.Types;

namespace VM.Services.Implementation.Types
{
    public class ScenarioXML : IScenario
    {
        public List<Scenario> ProcessFile(string dataFile)
        {
            var scenarios = GetScenarios(dataFile);
            var groupedScenarios = GroupScenarios(scenarios);

            return groupedScenarios.OrderBy(o => o.Surname)
                                   .ThenBy(o => o.Forename)
                                   .ThenBy(o => o.CreationDate)
                                   .ToList();
        }

        private static IEnumerable<Scenario> GetScenarios(string dataFile)
        {
            IEnumerable<Scenario> scenarios;
            var element = XElement.Load(dataFile);

            scenarios = element.Descendants("Scenario")
            .Select(s => new Scenario
            {
                ScenarioId = (string)s.Element("ScenarioID"),
                ScenarioName = (string)s.Element("Name"),
                Surname = (string)s.Element("Surname"),
                Forename = (string)s.Element("Forename"),
                UserId = (string)s.Element("UserID"),
                NoOfMonths = (string)s.Element("NumMonths"),
                MarketId = (string)s.Element("MarketID"),
                NetworkLayerId = (string)s.Element("NetworkLayerID"),
                SampleDate = s.Element("SampleDate") != null ? (DateTime)s.Element("SampleDate")
                                                             : DateTime.MinValue,
                CreationDate = s.Element("CreationDate") != null ? (DateTime)s.Element("CreationDate")
                                                                 : DateTime.MinValue,
            });

            return scenarios;
        }

        private static IEnumerable<Scenario> GroupScenarios(IEnumerable<Scenario> scenarios)
        {
            return scenarios.GroupBy(x => new
            {
                x.UserId,
                x.Surname,
                x.Forename,
                x.MarketId,
                x.NetworkLayerId,
                x.CreationDate,
                x.NoOfMonths,
                x.SampleDate
            })
            .Select(g => new Scenario
            {
                Surname = g.Key.Surname,
                Forename = g.Key.Forename,
                UserId = g.Key.UserId,
                NoOfMonths = g.Key.NoOfMonths,
                MarketId = g.Key.MarketId,
                NetworkLayerId = g.Key.NetworkLayerId,
                SampleDate = g.Key.SampleDate,
                CreationDate = g.Key.CreationDate
            });
        }
    }
}
