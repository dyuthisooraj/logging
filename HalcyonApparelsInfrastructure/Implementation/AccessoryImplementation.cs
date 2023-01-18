using HalcyonApparelsApplication.Interfaces;
using HalcyonApparelsDomain.Entities;
using HalcyonApparelsInfrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalcyonApparelsInfrastructure.Implementation
{
    public class AccessoryImplement : IAccessory
    {
        private readonly AppDBContext _dbobj;

        public object AccessoryDetails => throw new NotImplementedException();

        public AccessoryImplement(AppDBContext _dboj)
        {
            _dbobj = _dboj;
        }
        public List<AccessoryDetails> Get()
        {
            return _dbobj.AccessoryDetails.ToList();
        }

        //public void Post(AccessoryDetails accessory,string ptype)
        
        public void Post(AccessoryDetails accessory)
        {
            _dbobj.AccessoryDetails.Add(accessory);
            _dbobj.SaveChanges();
        }
        public void Delete(int id)
        {
            AccessoryDetails acc1 = _dbobj.AccessoryDetails.FirstOrDefault(i => i.AccessoryId == id);
            if (acc1 != null)
            {
                _dbobj.Remove(acc1);
                _dbobj.SaveChanges();
            }
        }


        public AccessoryDetails Get(int id)
        {
            return _dbobj.AccessoryDetails.FirstOrDefault(i => i.AccessoryId == id);
        }
        public void Edit(AccessoryDetails accs)
        {
            AccessoryDetails acc2 = _dbobj.AccessoryDetails.FirstOrDefault(i => i.AccessoryId == accs.AccessoryId);
            if (acc2 != null)
            {
                _dbobj.AccessoryDetails.Remove(acc2);
                _dbobj.AccessoryDetails.Add(accs);
                _dbobj.SaveChanges();
            }
        }

       
    }
}
