using System;

namespace VM.Models
{
    //<Scenario>
    //  <ScenarioID>58</ScenarioID>
    //  <Name>Scenario</Name>
    //  <Surname>Marriott</Surname>
    //  <Forename>Gerald</Forename>
    //  <UserID>91F9E135-94F3-4210-87AB-E953779545FB</UserID>
    //  <SampleDate>2013-02-01T06:01:00</SampleDate>
    //  <CreationDate>2013-02-01T14:11:00</CreationDate>
    //  <NumMonths>12</NumMonths>
    //  <MarketID>2</MarketID>
    //  <NetworkLayerID>1</NetworkLayerID>
    //</Scenario>

    public class Scenario
    {
        public string ScenarioId { get; set; }
        public string ScenarioName { get; set; }
        public string Surname { get; set; }
        public string Forename { get; set; }
        public string UserId { get; set; }
        public DateTime SampleDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string NoOfMonths { get; set; }
        public string MarketId { get; set; }
        public string NetworkLayerId { get; set; }

        public string FullName => Surname.ToUpper() + " " + Forename.ToUpper();

        public string CreationDateForDisplay => CreationDate == DateTime.MinValue ? string.Empty 
                                                                                  : CreationDate.ToString(SystemConstants.DATE_FORMAT);

        public string SampleDateForDisplay => SampleDate == DateTime.MinValue ? string.Empty
                                                                              : SampleDate.ToString(SystemConstants.DATE_FORMAT);
    }
}
