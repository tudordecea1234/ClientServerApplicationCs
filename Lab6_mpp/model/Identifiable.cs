using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_mpp.model
{
    public interface Identifiable<TID>
    {
         TID ID { get; set; }
        
    }
}