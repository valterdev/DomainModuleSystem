namespace OpenGameFramework
{
    public class HealthManager : SingletonCrossScene<HealthManager>
    {
        public int Health { get; set; } = 100;
        
    }
}