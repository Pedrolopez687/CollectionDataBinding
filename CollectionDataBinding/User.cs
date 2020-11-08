using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionDataBinding
{
    class User
    {
        private string name;
        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                }
            }
        }
    }
}
