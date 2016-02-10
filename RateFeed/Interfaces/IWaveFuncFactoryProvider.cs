namespace Internovus.Wpf.Training.RateFeed.Interfaces
{
    public interface IWaveFuncFactoryProvider
    {
        IWaveFuncFactory GetWaveFuncFactory(string waveType);
    }
}
