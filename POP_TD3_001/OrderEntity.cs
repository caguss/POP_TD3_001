using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_TD3_001
{
    public class OrderEntity
    {
        private string order_id; //작업지시
        private string prod_num;// 품번
        private int amount; // 수량
        private string process; // 공정
        private string worker; // 작업자
        private string product_type;//제품타입
        //제품수량단위
        //생성수량 => 공정이 절단일 경우 OR 입고시에 넣음
        //출하시간 -> 출하시만
        //공급사 x
        //파일경로 x
        //수정시간 : 작업완료시간
        private string machine_name;//작업설비
        private string remark;//비고

        public string Order_id
        {
            get
            {
                return order_id;
            }

            set
            {
                order_id = value;
            }
        }

        public string Prod_num
        {
            get
            {
                return prod_num;
            }

            set
            {
                prod_num = value;
            }
        }

        public int Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }

        public string Process
        {
            get
            {
                return process;
            }

            set
            {
                process = value;
            }
        }

        public string Worker
        {
            get
            {
                return worker;
            }

            set
            {
                worker = value;
            }
        }

        public string Product_type
        {
            get
            {
                return product_type;
            }

            set
            {
                product_type = value;
            }
        }

        public string Remark
        {
            get
            {
                return remark;
            }

            set
            {
                remark = value;
            }
        }

        public string Machine_name
        {
            get
            {
                return machine_name;
            }

            set
            {
                machine_name = value;
            }
        }
    }
}
