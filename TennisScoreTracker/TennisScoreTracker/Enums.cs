using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisScoreTracker
{
    public enum ActionType
    {
        //this would be roger
        Player1WinsAPoint,
        //this would be tim. I made it generic so it could be any player
        Player2WinsAPoint
    }
}
