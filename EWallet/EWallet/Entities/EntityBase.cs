using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Entities
{
    public abstract class EntityBase
    {
        public bool IsValid
        {
            get
            {
                return Validate();
            }
        }

        public abstract bool Validate();
    }
}
