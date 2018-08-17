using System;
using CableModemInfoService.Processors;


namespace CableModemInfoService.Exceptions 
{
    [System.Serializable]
    public class UnsupportedModelException : System.Exception
    {
        public UnsupportedModelException(ModemModel model) : base($"{Enum.GetName(typeof(ModemModel),model)} is not implemented") {}
    }
    
}