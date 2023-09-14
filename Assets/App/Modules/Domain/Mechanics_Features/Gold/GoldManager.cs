namespace OpenGameFramework
{
    public class GoldManager : SingletonCrossScene<GoldManager>
    {
        public int Gold { get; set; } = 100;
        
    }
}