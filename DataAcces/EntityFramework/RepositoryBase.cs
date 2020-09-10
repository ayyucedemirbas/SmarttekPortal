using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcces;

namespace DataAcces.EntityFramework
{
    public class RepositoryBase
    {
        protected static DatabaseContext db;
        private static object _LockObj = new object();

        protected RepositoryBase()
        {
            CreateContext();
        }
        private static void CreateContext()
        {
            if (db ==null)
            {
                lock (_LockObj)
                {
                    if (db==null)
                    {
                        db = new DatabaseContext();
                    }
                }
            }
        }

    }
}
