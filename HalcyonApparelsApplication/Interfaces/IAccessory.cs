using HalcyonApparelsDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalcyonApparelsApplication.Interfaces
{
    public interface IAccessory
    {
        List<AccessoryDetails> Get();

        void Post(AccessoryDetails accessory);
        void Delete(int id);

        AccessoryDetails Get(int id);
        void Edit(AccessoryDetails acc3);

    }
}
