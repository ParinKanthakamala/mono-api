namespace Molecular.Routing
{
    public enum RoutingStatus
    {
        Ok,
        UnknownCommand,
        InvalidParameters,
        InvalidDefault,
        PartialCommand,
        AmbigousParameters
    }
}