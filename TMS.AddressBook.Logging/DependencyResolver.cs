using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.AddressBook.Resolver;

namespace TMS.AddressBook.Logging
{
    [Export(typeof(IComponent))]
    class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterTypeWithControlledLifeTime<ILogger, Logger>();
        }
    }
}
