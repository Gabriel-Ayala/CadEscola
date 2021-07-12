using System;

namespace CadEscola.Utils
{
    public class Date
    {

        public static int Age(DateTime birthday)
        {
            var _birthday = birthday;
            var age = DateTime.Today.Year - _birthday.Year;

            if (birthday.Date > DateTime.Today.AddYears(-age)) age--;

            return age;
        }
    }
}
