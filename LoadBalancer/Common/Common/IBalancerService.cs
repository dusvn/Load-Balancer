using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [ServiceContract]
    public interface IBalancerService
    {
        [OperationContract]
        void zapisiIteme(Item item);
    }
}
