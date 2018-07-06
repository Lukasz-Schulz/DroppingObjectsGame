using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra2WPF
{
    /// <summary>
    /// Singleton making all the registered object factories availible
    /// </summary>
    public class AvailableFactoryList
    {
        private static AvailableFactoryList instance = null;

        public List<ObjectFactory> list = new List<ObjectFactory>();//actual list of factories

        private AvailableFactoryList() { }

        public static AvailableFactoryList Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AvailableFactoryList();
                }
                return instance;
            }
        }

        public void AddToList(ObjectFactory thisfactory)//method used in factories constructor to add them automaticly to the list
        {
            list.Add(thisfactory);
        }
    }
}
