using OpenGameFramework;

namespace App
{
    public partial class App
    {
		public static GoldManager GoldManager;
		public static HealthManager HealthManager;
		public static ShopManager ShopManager;
		public static RatingManager RatingManager;
		public static GameCoreManager GameCoreManager;

        private void InitStaticAPI() {
			GoldManager = GoldManager.Instance();
			HealthManager = HealthManager.Instance();
			ShopManager = ShopManager.Instance();
			RatingManager = RatingManager.Instance();
			GameCoreManager = GameCoreManager.Instance();

        }
    }
}