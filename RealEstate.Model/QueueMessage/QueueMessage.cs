using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Model.QueueMessage
{
    public abstract class QueueMessage
    {
        public QueueMessage(string messageName)
        {
            MessageName = messageName;
        }

        public string MessageName { get; }
    }
}
