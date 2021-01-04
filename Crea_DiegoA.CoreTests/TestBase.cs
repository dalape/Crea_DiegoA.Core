using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crea_DiegoA.CoreTests
{
    public class TestBase
    {
        protected string GenerateRandomName(string nameBase)
        {
            Random random = new Random();
            int randomNum = random.Next(1000, 9999999);

            return $"{nameBase}_{randomNum}";
        }

        protected int GenerateRandomNumber()
        {
            Random random = new Random();
            return random.Next(1000, 9999999);
        }
    }
}
