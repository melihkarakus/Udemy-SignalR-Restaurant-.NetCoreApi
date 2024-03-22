using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    //Kendine özgü imza tanımlamak için oluşturulur
    public interface IAboutDal : IGenericDal<About>
    {
    }
}
