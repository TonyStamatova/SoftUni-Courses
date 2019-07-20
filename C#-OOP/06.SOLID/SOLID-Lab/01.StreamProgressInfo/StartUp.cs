namespace P01.Stream_Progress
{
    using System;

    public class StartUp
    {
        static void Main()
        {
            Music music = new Music("ala", "bala", 34, 453);
            StreamProgressInfo info = new StreamProgressInfo(music);
            Console.WriteLine(info.CalculateCurrentPercent());
        }
    }
}
