using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public interface IManaged
    {
        Employee Manager { get; set; }
        void AssignManager(Employee manager);
    }
}
