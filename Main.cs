using BTD_Mod_Helper;

using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.ModOptions;

using Il2CppAssets.Scripts.Data.Boss;
using Il2CppAssets.Scripts.Models.Rounds;
using MelonLoader;

[assembly: MelonInfo(typeof(MoabBosses.Main), "Moab Bosses", "1.1.0", "emeryllium")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace MoabBosses
{
    public class Main : BloonsTD6Mod
    {
        public static readonly ModSettingEnum<BossType> boss = new(BossType.Bloonarius)
        {
            labelFunction = x => x.ToString()
        };
    }

    public class RoundSet : ModRoundSet
    {
        public override string BaseRoundSet => RoundSetType.Default;
        public override int DefinedRounds => BaseRounds.Count;
        public override string DisplayName => "Moab Bosses";
        public override string Icon {
            get
            {
                return Main.boss.GetValue() switch
                {
                    BossType.Bloonarius => VanillaSprites.BloonariusBadge,
                    BossType.Lych => VanillaSprites.LychBadge,
                    BossType.Vortex => VanillaSprites.VortexBadge,
                    BossType.Phayze => VanillaSprites.PhayzeBadge,
                    BossType.Dreadbloon => VanillaSprites.DreadbloonBadge,
                    BossType.Blastapopoulos => VanillaSprites.BlastapopoulosBadge,
                    _ => VanillaSprites.BossMedalEventGoldSilverMedal,
                };
            }
        }
        public override void ModifyRoundModels(RoundModel roundModel, int round)
        {
            foreach (var group in roundModel.groups)
            {
                group.bloon = promoteBloon(group.bloon, Main.boss.Name);
            }
        }

        public static string promoteBloon(string bloon, string boss)
        {
            return bloon switch
            {
                "Moab" => boss + "1",
                "MoabFortified" => boss + "Elite1",
                "Bfb" => boss + "2",
                "BfbFortified" => boss + "Elite2",
                "Zomg" => boss + "3",
                "ZomgFortified" => boss + "Elite3",
                "DdtCamo" => boss + "4",
                "DdtFortifiedCamo" => boss + "Elite4",
                "Bad" => boss + "5",
                "BadFortified" => boss + "Elite5",
                _ => bloon,
            };
        }
    }
}