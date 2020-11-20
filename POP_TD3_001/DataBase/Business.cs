
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

        public void Change_Connection(string machine_name)
        {
            prov.Change_Connection(machine_name);
        }

        public void Resource_In(OrderEntity v_entity)
        {
            prov.Resource_In(v_entity);
        }

        public void Resource_Out(OrderEntity entity)
        {
            prov.Resource_Out(entity);

        }

        public void Work_Finish_I10(OrderEntity entity)
        {
            prov.Work_Finish_I10(entity);

        }

        public void Product_Out_I10(OrderEntity entity)
        {
            prov.Product_Out_I10(entity);

        }
    }
}
