using System;
using cablemodem_info.Processors;


namespace cablemodem_info.Exceptions 
{
    [System.Serializable]
    public class UnsupportedModelException : System.Exception
    {
        public UnsupportedModelException(ModemModel model) : base($"{Enum.GetName(typeof(ModemModel),model)} is not implemented") {}
    }
    
}