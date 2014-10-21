using System.Collections.Generic;
using System.Drawing;
using NeltharionRPGGame.Structure;

namespace NeltharionRPGGame.Helper
{
    public static class ImageLoader
    {
        private const string DirPath = "../../Graphics/";

        private const string MageImagePath = DirPath + "mage.png";
        private const string MageFlippedImagePath = DirPath + "mage-flipped.png";
        private const string WitchImagePath = DirPath + "witch.png";
        private const string FighterImagePath = DirPath + "fighter.png";
        private const string FighterFlippedImagePath = DirPath + "fighter-flipped.png";
        private const string SwordImagePath = DirPath + "sword.png";
        private const string DefaulthWeaponImagePath = DirPath + "default.png";
        private const string RedHealthHeartImagePath = DirPath + "redHeart.png";
        private const string BlackHealthHeartImagePath = DirPath + "blackHeart.png";
        private const string AxeImagePath = DirPath + "axe.png";
        private const string BowImagePath = DirPath + "bow.png";
        private const string ClubImagePath = DirPath + "club.png";
        private const string PikeImagePath = DirPath + "pike.png";
        private const string PoleArmImagePath = DirPath + "poleArm.png";
        private const string PotionImagePath = DirPath + "potion.png";
        private const string StuffImagePath = DirPath + "staff.png";
        private const string BucklerImagePath = DirPath + "buckler.png";
        private const string TowerShieldImagePath = DirPath + "towerShield.png";

        private static readonly Dictionary<SpriteType, Image> GameObjectImages;

        static ImageLoader()
        {
            GameObjectImages = new Dictionary<SpriteType, Image>()
            {
                {SpriteType.MageRight, Image.FromFile(MageImagePath)},
                {SpriteType.MageLeft, Image.FromFile(MageFlippedImagePath)},
                {SpriteType.Witch, Image.FromFile(WitchImagePath)},
                {SpriteType.FighterRight, Image.FromFile(FighterImagePath)},
                {SpriteType.FighterLeft, Image.FromFile(FighterFlippedImagePath)},
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
