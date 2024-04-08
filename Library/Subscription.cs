using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Subscription
    {
        public bool IsSubscribed(Client client)
        {
            return client.GetSubscription();
        }
    }
}
