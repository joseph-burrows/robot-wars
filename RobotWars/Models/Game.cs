using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars.Models
{
    public class Game
    {
        public Arena Arena { get; set; }
        public List<Robot> Robots { get; set; }
    }
}
