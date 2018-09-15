using System;
using CableModemInfoService.lib.Processors;

namespace CableModemInfoService.lib.Exceptions 
{
    [System.Serializable]
    public class UnsupportedModelException : System.Exception
    {
        public UnsupportedModelException(ModemModel model) : base($"{Enum.GetName(typeof(ModemModel),model)} is not implemented") {}
    }
    
}