using System;

namespace BeFaster.App.Solutions.CHK
{
    public class InvalidSkuException: Exception
    {
        public InvalidSkuException(char invalidSku) : base($"SKU {invalidSku} not found!") { }
    }
}
