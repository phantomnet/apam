namespace apam
{
    public interface IAutoCallService
    {
        Task<bool> PlaceCallAsync(string phoneNumber);
    }
}
