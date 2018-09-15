namespace CableModemInfoService.lib.Processors.SB_6183.Reports
{
    public enum StartupRows
    {
        AquireDownstreamChannel = 5,
        ConnectivityState = 9,
        BootState = 11
    }
    
    public enum StartupRowCellIndexes
    {
        Procedure = 0,
        Status = 1,
        Comment = 2
    }
}