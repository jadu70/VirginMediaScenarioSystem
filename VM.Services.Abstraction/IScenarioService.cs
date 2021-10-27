using System;
using System.Collections.Generic;
using VM.Models;

namespace VM.Services.Abstraction
{
    public interface IScenarioService
    {
        List<Scenario> ScenariosToDisplay();
    }
}
