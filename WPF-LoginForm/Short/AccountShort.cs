using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_LoginForm.Short
{
    internal class AccountShort
    {
        public byte Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public string Role { get; set; }
        public string FIOEmployee { get; set; }
        public string Post { get; set; }

    }
}
