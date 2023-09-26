using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationLab_Opdracht2
{
    public class PostData
    {
        public class PostDataTemperature
        {
            public int Temperature { get; set; }
        }

        public class PostDataLighting
        {
            public bool Toggle { get; set; }
        }

        public class PostDataSunProtector
        {
            public bool Toggle { get; set; }
        }
    }
}
