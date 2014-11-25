using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace League.Utilities
{

    public enum FixtureAction
    {
        None = 0,
        YelowCard = 1,
        RedCard = 2,
        Goal = 4
    }

    public enum FixtureState
    {
        None = 0,
        Start = 1,
        Stop = 2
    }

    public enum FixturePeriod
    {
        None = 0,
        FirstHalf = 1,
        SecondHalf = 2,
        InjuryTime = 4
    }
}