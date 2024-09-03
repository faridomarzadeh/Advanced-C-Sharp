using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class Employee: BaseEmployee, IManaged
    {
        public IManager Manager { get; set; } = null;

        public virtual void AssignManager(IManager manager)
        {
            this.Manager = manager;
        }

    }
}
