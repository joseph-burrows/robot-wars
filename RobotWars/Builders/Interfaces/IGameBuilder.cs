using RobotWars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars.Services
{
    public interface IGameBuilder
    {
        Game Build(List<string> input);
    }
}
