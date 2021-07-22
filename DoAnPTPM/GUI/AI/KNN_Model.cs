using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.AI
{

    public class KNN_Model
    {
        
        int m, k = 5;
        HangHoa[] data = new HangHoa[1000];
        HangHoa[] Distance = new HangHoa[1000];
        HangHoa[] dt_k = new HangHoa[1000];
        
        public int calculateDistance(HangHoa data, HangHoa input)
        {
            int giaBan;
            giaBan = (int)Math.Pow(data.GiaBan1 - input.GiaBan1,2);
            return (int)Math.Sqrt(giaBan);

        }


        public void getValue(HangHoa[] data, int n , HangHoa input, HangHoa[] output)
        {
            m = 0;
            for(int i = 0; i < n; i++)
            {
                HangHoa h = new HangHoa();
                h.GiaBan1 = calculateDistance(data[i],input);
                h.TenHang1 = data[i].TenHang1;
                output[m] = h;
                m++;
            }    

        }

         public void sortUp(HangHoa[] output)
        {
            for(int i = 0; i < m - 1; i++)
            {
                for(int j = i+1;j <m; j++)
                {
                    if(output[j].GiaBan1 < output[i].GiaBan1)
                    {
                        HangHoa temp;
                        temp = output[i];
                        output[i] = output[j];
                        output[j] = temp;
                    }    
                }    
            }    
        }

        public void swap(HangHoa a, HangHoa b)
        {
            HangHoa temp;
            temp = a;
            a = b;
            b = temp;
        }

        public void getK_Value(HangHoa[] output, HangHoa[] value_out)
        {
            for(int i = 0; i < k; i++)
            {
                value_out[i] = output[i];
            }    
        }

        public int count(HangHoa[] value_out, HangHoa h)
        {
            int count = 0;
            for(int i = 0; i < k; i++)
            {
                if(string.Compare(value_out[i].TenHang1,h.TenHang1,true)==0)
                {
                    count++;
                }    
            }
            return count;
        }

        public string check_Label(HangHoa[] value_out)
        {
            int MAX = count(value_out,value_out[0]), vt= 0;
            for(int i = 1; i < k;i++)
            {
                if(count(value_out,value_out[i])>MAX)
                {
                    MAX = count(value_out, value_out[i]);
                    vt = i;
                }    
            }
            return value_out[vt].TenHang1;
        }
    }
}
