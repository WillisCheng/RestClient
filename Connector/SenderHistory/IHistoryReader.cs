namespace SenderHistory
{
    public interface IHistoryReader
    {
        ConnectHistory Load();

        //void Save();
    }
}