using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODSaveManipulator
{

    /// <summary>
    /// The class for handling the info option for save manipulator.
    /// </summary>
    class Info
    {

        /// <summary>
        /// Structure that is used to store the time of the save.
        /// </summary>
        public struct qtime_s
        {
            int tm_sec;
            int tm_min;
            int tm_hour;
            int tm_mday;
            int tm_mon;
            int tm_year;
            int tm_wday;
            int tm_yday;
            int tm_isdst;
        }
    }
}
