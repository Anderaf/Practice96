using System;
using System.Collections.Generic;
using System.Text;

namespace Practice96
{
    internal class AssetNotFoundException : Exception
    {
        public AssetNotFoundException()
        {}
        public AssetNotFoundException(string message) : base(message)
        {}
    }
}
