namespace Mozu.Api.Contracts.PaymentService.Extensibility.V1
{
    public enum ConnectionStatuses
    {
        Success,
        Timeout,
        Reject,
        Unauth,
        Error,
        NotFound
    }
}