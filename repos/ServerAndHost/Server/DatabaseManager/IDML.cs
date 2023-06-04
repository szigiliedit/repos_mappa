using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DatabaseManager
{
    internal interface IDML
    {
        int Insert(Record record);//CRUD Create
        int Update(Record record);//CRUD Update
        int Delete(int id);//CRUD Delete
    }
}
