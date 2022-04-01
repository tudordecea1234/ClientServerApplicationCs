using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_mpp.model
{
    public class CharityCase : Identifiable<long>
    {
        private string caseName;
        private float totalAmount;
        public CharityCase(string name, float sum)
        {
            caseName = name;
            totalAmount = sum;
        
        }

        public string CaseName { get => caseName; set => caseName = value; }
        public float TotalAmount { get => totalAmount; set => totalAmount = value; }

        public long ID
        {
            get; set; 
            
        }
        public override string ToString()
        {
            return "Case id: " + ID + " " + caseName + " " + totalAmount;
        }
    }
}