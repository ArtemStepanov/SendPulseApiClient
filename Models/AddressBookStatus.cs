namespace Stxima.SendPulseClient.Models;

public enum AddressBookStatus
{
    Active = 0,
    MarkedAsRemoved = 1,
    AwaitingUserResponse = 3,
    BlockedByService = 4,
    BlockedByDaemon = 5
}
