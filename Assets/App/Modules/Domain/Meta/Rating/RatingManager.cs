namespace OpenGameFramework
{
    public class RatingManager : SingletonCrossScene<RatingManager>
    {
        public int Rating { get; set; } = 100;
    }
}