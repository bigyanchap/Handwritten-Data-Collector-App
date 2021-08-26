using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Enums
    {
        
        public class _class
        {
            public int classId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public static List<_class> classList
            {
                get
                {
                    return new List<_class>
                    {
                        new _class{classId=1,Name="bra",Description="ब्र"},
                        new _class{classId=2,Name="tta",Description="त्त"},
                        new _class{classId=3,Name="mra",Description="म्र"},
                        new _class{classId=4,Name="mri",Description="मृ"},
                        new _class{classId=5,Name="dwa",Description="द्व"},
                        new _class{classId=6,Name="hya",Description="ह्य"},
                        new _class{classId=7,Name="hra",Description="ह्र"},
                        new _class{classId=8,Name="gri",Description="गृ"},
                        new _class{classId=9,Name="rhi",Description="ॠ"},
                        new _class{classId=10,Name="kra",Description="क्र"},
                        new _class{classId=11,Name="pra",Description="प्र"},
                        new _class{classId=12,Name="dya",Description="द्य"},
                        new _class{classId=13,Name="dda",Description="दृ"},
                        new _class{classId=14,Name="hri",Description="हृ"},
                        new _class{classId=15,Name="traw",Description="ट्र"},
                        new _class{classId=16,Name="tra",Description="त्र"},
                        new _class{classId=17,Name="dra",Description="द्र"},
                        new _class{classId=18,Name="dma",Description="द्म"},
                        new _class{classId=19,Name="shra",Description="श्र"},
                        new _class{classId=20,Name="pri",Description="पृ"}
                    };
                }
            }
        }
    }
}
