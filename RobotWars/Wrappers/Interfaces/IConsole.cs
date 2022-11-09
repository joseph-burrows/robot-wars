using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars.Services
{
    public interface IConsole
    {
        string ReadLine();
        void WriteLine(string value);
    }
}
