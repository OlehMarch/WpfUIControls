using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfUIControls.API.Locale
{
    public class English : ALanguage
    {
        public static English GetInstance()
        {
            if (lang == null)
            {
                lang = new English();
            }
            return lang;
        }
        private static English lang;


        private English()
        {
            Collisions = "Collision";
        }

    }
}
