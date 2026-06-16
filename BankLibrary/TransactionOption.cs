using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public class TransactionOption
    {
        public bool IsSelected { get; set; }
        public string DisplayName { get; set; }
        public string ActionCode { get; set; }

        public override string ToString()
        {
            return DisplayName;
        }

    }
}
