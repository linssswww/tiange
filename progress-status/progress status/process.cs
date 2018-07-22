using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace progress_status
{
    public class Process
    {
        public Process() { }
        public List<Employ> getListUser()
        {
            List<Employ> usrgroup = new List<Employ>();
            usrgroup = data.getUserList();
            return usrgroup;
        }

        public void getCurrentProgram()
        {

        }
        public Data data = new Data();
        
    }
}
