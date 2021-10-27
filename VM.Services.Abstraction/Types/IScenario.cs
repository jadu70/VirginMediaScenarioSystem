using System;
using System.Collections.Generic;
using System.Text;
using VM.Models;

namespace VM.Services.Abstraction.Types
{
    public interface IScenario
    {
        List<Scenario> ProcessFile(string dataFile);
    }
}
