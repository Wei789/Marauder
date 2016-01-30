using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marauder.BLL.ViewModels
{
    /// <summary>
    /// sample A class
    /// </summary>
    public class SampleView
    {
        /// <summary>
        /// property a
        /// </summary>
        public int a { get; set; }

        /// <summary>
        /// property SampleBClass
        /// </summary>
        public SampleBClass bClass { get; set; }
    }

    /// <summary>
    /// sample B class
    /// </summary>
    public class SampleBClass
    {
        /// <summary>
        /// property b of SampleBClass
        /// </summary>
        public string b { get; set; }
    }
}
