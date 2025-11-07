namespace apam
{
    public interface ISpeechToText
    {
        bool IsSupported { get; }
        Task<bool> StartAsync(CancellationToken ct = default); // returns true if started
        void Stop();
        event EventHandler<string>? PartialResult;
        event EventHandler<string>? FinalResult;
        event EventHandler<string>? Error;
    }
}
