using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public interface IOrders
    {

         void ADDUpdate(Dish dish);

         void DELETEUpdate(Dish dish);

         void NextPhase();

        decimal return_price();


    }
}
