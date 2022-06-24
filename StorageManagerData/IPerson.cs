using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageManagerData
{
    public interface IPerson
    {
        int Id { get; set; }
        string Name { get; set; }
        string SecondName { get; set; }  
        
    }
}
