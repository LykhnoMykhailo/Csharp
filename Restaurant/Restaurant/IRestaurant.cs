using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    internal interface IRestaurant
    {
        void Create_Order();

        void Remove_Order(int id);
        void Show_Orders();

    }
}
