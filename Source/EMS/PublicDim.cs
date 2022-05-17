using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMS
{
    public class PublicDim
    {
        public static DBSR.DBServiceClient client = null;
        static PublicDim()
        {
            client = new DBSR.DBServiceClient();
        }
    }
}
