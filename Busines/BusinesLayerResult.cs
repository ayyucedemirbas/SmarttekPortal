using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Messasages;

namespace Busines
{
    public class BusinesLayerResult<T> where T : class
    {
        public List<ErrorMesasagesObject> Errors { get; set; }
        public T result { get; set; }

        public BusinesLayerResult()
        {
            Errors = new List<ErrorMesasagesObject>();
        }
        public void addError(ErrosMesasagesCode code, string messege)
        {
            Errors.Add(new ErrorMesasagesObject() { code = code, Message = messege });
        }
    }
}
