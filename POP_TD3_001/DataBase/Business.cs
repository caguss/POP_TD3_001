
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_TD3_001
{
    public class SettingBusiness
    {
        Provider prov = new Provider();
        public DataTable Machine_Refresh(string res_id)
        {
            DataTable pDataTable = prov.Machine_Refresh(res_id);
            return pDataTable;
        }

        public DataTable Machine_List()
        {
            DataTable pDataTable = prov.Machine_List();
            return pDataTable;
        }

        public void Change_Connection()
        {
            prov.Change_Connection();
        }
    }
}
