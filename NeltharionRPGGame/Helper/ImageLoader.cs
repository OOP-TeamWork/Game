using System.Collections.Generic;
using System.Drawing;
using NeltharionRPGGame.Structure;

namespace NeltharionRPGGame.Helper
{
    public static class ImageLoader
    {
        private const string MageImagePath = "../../Graphics/mage.png";
        private const string WitchImagePath = "../../Graphics/witch.png";
        private const string FighterImagePath = "../../Graphics/fighter.png";
        private const string SwordImagePath = "../../Graphics/sword.png";
        private const string DefaulthWeaponImagePath = "../../Graphics/default.png";
        private const string RedHealthHeartImagePath = "../../Graphics/redHeart.png";
        private const string BlackHealthHeartImagePath = "../../Graphics/blackHeart.png";
        private const string AxeImagePath = "../../Graphics/axe.png";
        private const string BowImagePath = "../../Graphics/bow.png";
        private const string ClubImagePath = "../../Graphics/club.png";
        private const string PikeImagePath = "../../Graphics/pike.png";
        private const string PoleArmImagePath = "../../Graphics/poleArm.png";
        private const string PotionImagePath = "../../Graphics/potion.png";
        private const string StuffImagePath = "../../Graphics/stuff.png";
        private const string BucklerImagePath = "../../Graphics/buckler.png";
        private const string TowerShieldImagePath = "../../Graphics/towerShield.png";

        private static Dictionary<SpriteType, Image> GameObjectImages;

        static ImageLoader()
        {
            GameObjectImages = new Dictionary<SpriteType, Image>()
            {
                {SpriteType.Mage, Image.FromFile(MageImagePath)},
                {SpriteType.Witch, Image.FromFile(WitchImagePath)},
                {SpriteType.Fighter, Image.FromFile(FighterImagePath)},
                {SpriteType.Sword, Image.FromFile(SwordImagePath)},
                {SpriteType.Axe, Image.FromFile(AxeImagePath)},
                {SpriteType.Bow, Image.FromFile(BowImagePath)},
                {SpriteType.Pike, Image.FromFile(PikeImagePath)},
                {SpriteType.PoleArm, Image.FromFile(PoleArmImagePath)},
                {SpriteType.Potion, Image.FromFile(PotionImagePath)},
                {SpriteType.Stuff, Image.FromFile(StuffImagePath)},
                {SpriteType.Club, Image.FromFile(ClubImagePath)},
                {SpriteType.DefaultWeapon, Image.FromFile(DefaulthWeaponImagePath)},
                {SpriteType.RedHeart, Image.FromFile(RedHealthHeartImagePath)},
                {SpriteType.BlackHeart, Image.FromFile(BlackHealthHeartImagePath)},
                {SpriteType.Buckler, Image.FromFile(BucklerImagePath)},
                {SpriteType.TowerShield, Image.FromFile(TowerShieldImagePath)}
            };
        }

        public static Image GetObjectImage(SpriteType sprite)
        {
            return GameObjectImages[sprite];
        }

        public static void AddImage(SpriteType objectSpriteType, Image image)
        {
            GameObjectImages.Add(objectSpriteType, image);
        }
    }
}
