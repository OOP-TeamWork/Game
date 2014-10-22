using System.Collections.Generic;
using System.Drawing;
using NeltharionRPGGame.Data;
using NeltharionRPGGame.Structure;

namespace NeltharionRPGGame.Helper
{
    public static class ImageLoader
    {
        private const string DirPath = "../../Graphics/";

        private const string MageImagePath = DirPath + "mage.png";
        private const string MageFlippedImagePath = DirPath + "mage-flipped.png";
        private const string PaladinImagePath = DirPath + "paladin.png";
        private const string PaladinFlippedImagePath = DirPath + "paladin-flipped.png";
        private const string VikingImagePath = DirPath + "viking.png";
        private const string VikingFlippedImagePath = DirPath + "viking-flipped.png";
        private const string WitchImagePath = DirPath + "witch.png";
        private const string WitchFlippedImagePath = DirPath + "witch-flipped.png";
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
        private const string StuffImagePath = DirPath + "staff.png";
        private const string BucklerImagePath = DirPath + "buckler.png";
        private const string TowerShieldImagePath = DirPath + "towerShield.png";
        private const string BurningGroundSpellImage = DirPath + "fire.png";
        private const string HealthPotionImagePath = DirPath + "healthPotion.png";
        private const string AttackPotionImagePath = DirPath + "attackPotion.png";
        private const string DefencePotionImagePath = DirPath + "defencePotion.png";

        private static readonly Dictionary<SpriteType, Image> GameObjectImages;

        static ImageLoader()
        {
            GameObjectImages = new Dictionary<SpriteType, Image>()
            {
                {SpriteType.MageRight, Image.FromFile(MageImagePath)},
                {SpriteType.MageLeft, Image.FromFile(MageFlippedImagePath)},
                {SpriteType.PaladinRight, Image.FromFile(PaladinImagePath)},
                {SpriteType.PaladinLeft, Image.FromFile(PaladinFlippedImagePath)},
                {SpriteType.VikingRight, Image.FromFile(VikingImagePath)},
                {SpriteType.VikingLeft, Image.FromFile(VikingFlippedImagePath)},
                {SpriteType.WitchLeft, Image.FromFile(WitchImagePath)},
                {SpriteType.WitchRight, Image.FromFile(WitchFlippedImagePath)},
                {SpriteType.FighterRight, Image.FromFile(FighterImagePath)},
                {SpriteType.FighterLeft, Image.FromFile(FighterFlippedImagePath)},
                {SpriteType.Sword, Image.FromFile(SwordImagePath)},
                {SpriteType.Axe, Image.FromFile(AxeImagePath)},
                {SpriteType.Bow, Image.FromFile(BowImagePath)},
                {SpriteType.Pike, Image.FromFile(PikeImagePath)},
                {SpriteType.PoleArm, Image.FromFile(PoleArmImagePath)},
                {SpriteType.Stuff, Image.FromFile(StuffImagePath)},
                {SpriteType.Club, Image.FromFile(ClubImagePath)},
                {SpriteType.DefaultWeapon, Image.FromFile(DefaulthWeaponImagePath)},
                {SpriteType.RedHeart, Image.FromFile(RedHealthHeartImagePath)},
                {SpriteType.BlackHeart, Image.FromFile(BlackHealthHeartImagePath)},
                {SpriteType.Buckler, Image.FromFile(BucklerImagePath)},
                {SpriteType.TowerShield, Image.FromFile(TowerShieldImagePath)},
                {SpriteType.BurningGround, Image.FromFile(BurningGroundSpellImage)},
                {SpriteType.HealthPotion, Image.FromFile(HealthPotionImagePath)},
                {SpriteType.AttackPotion, Image.FromFile(AttackPotionImagePath)},
                {SpriteType.DefensePotion, Image.FromFile(DefencePotionImagePath)}
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
