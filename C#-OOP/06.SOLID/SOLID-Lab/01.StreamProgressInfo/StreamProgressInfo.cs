namespace P01.Stream_Progress
{
    using P01.Stream_Progress.Contracts;

    public class StreamProgressInfo
    {
        private IStreamable streamedItem;

        public StreamProgressInfo(IStreamable streamedItem)
        {
            this.streamedItem = streamedItem;
        }

        public int CalculateCurrentPercent()
        {
            return (this.streamedItem.BytesSent * 100) / this.streamedItem.Length;
        }
    }
}
