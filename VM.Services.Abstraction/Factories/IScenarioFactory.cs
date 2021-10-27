using System;
using System.Collections.Generic;
using System.Text;
using VM.Services.Abstraction.Types;

namespace VM.Services.Abstraction.Factories
{
    public interface IScenarioFactory
    {
        IScenario GetScenario(string FileType);
    }
}
