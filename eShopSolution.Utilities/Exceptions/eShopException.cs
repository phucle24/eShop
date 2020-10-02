using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Utilities.Exeptions
{
    public class eShopException : Exception
    {
        public eShopException()
        {
        }

        public eShopException(string message)
            : base(message)
        {
        }

        public eShopException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}