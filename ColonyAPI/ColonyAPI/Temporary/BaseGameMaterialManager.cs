using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColonyAPI.Temporary
{
    class BaseGameMaterialManager
    {
        public static void initialiseMaterials()
        {
            Managers.MaterialManager.createMaterial("grasstemperate", "grassTemperate", "neutral", "grassGeneric", "grassGeneric");
            Managers.MaterialManager.createMaterial("grasstundra", "grassTundra", "neutral", "grassGeneric", "grassGeneric");
            Managers.MaterialManager.createMaterial("grasstaiga", "grassTaiga", "neutral", "grassGeneric", "grassGeneric");
            Managers.MaterialManager.createMaterial("grasssavanna", "grassSavanna", "neutral", "grassGeneric", "grassGeneric");
            Managers.MaterialManager.createMaterial("grassrainforest", "grassRainforest", "neutral", "grassGeneric", "grassGeneric");
            Managers.MaterialManager.createMaterial("sand", "sand", "neutral", "sand", "sand");
            Managers.MaterialManager.createMaterial("snow", "snow", "neutral", "snow", "snow");
            Managers.MaterialManager.createMaterial("dirt", "dirt", "neutral", "dirt", "dirt");
            Managers.MaterialManager.createMaterial("stoneblock", "stoneblock", "neutral", "stoneblock", "stoneblock");
            Managers.MaterialManager.createMaterial("planks", "planks", "neutral", "planks", "planks");
            Managers.MaterialManager.createMaterial("blackplanks", "blackplanks", "neutral", "planks", "planks");
            Managers.MaterialManager.createMaterial("redplanks", "redplanks", "neutral", "planks", "planks");
            Managers.MaterialManager.createMaterial("coatedplanks", "coatedplanks", "neutral", "coatedplanks", "planks");
            Managers.MaterialManager.createMaterial("adobe", "adobe", "neutral", "adobe", "adobe");
            Managers.MaterialManager.createMaterial("logtemperate", "logTemperate", "neutral", "log", "log");
            Managers.MaterialManager.createMaterial("logtaiga", "logTaiga", "neutral", "log", "log");
            Managers.MaterialManager.createMaterial("cherryblossom", "cherryBlossom", "neutral", "cherryBlossom", "cherryBlossom");
            Managers.MaterialManager.createMaterial("leavestemperate", "leavesTemperate", "neutral", "leavesTemperate", "leavesTemperate");
            Managers.MaterialManager.createMaterial("leavestaiga", "leavesTaiga", "neutral", "leavesTaiga", "leavesTaiga");
            Managers.MaterialManager.createMaterial("crate", "crate", "neutral", "crate", "crate");
            Managers.MaterialManager.createMaterial("stonebricks", "stoneBricks", "neutral", "stoneBricks", "stoneBricks");
            Managers.MaterialManager.createMaterial("workbenchtop", "workbenchTop", "neutral", "workbenchTop", "workbenchTop");
            Managers.MaterialManager.createMaterial("plasterblock", "plasterblock", "neutral", "plasterblock", "plasterblock");
            Managers.MaterialManager.createMaterial("furnaceside", "furnaceSide", "neutral", "furnaceSide", "furnaceSide");
            Managers.MaterialManager.createMaterial("furnaceunlittop", "furnaceUnlitTop", "neutral", "furnaceUnlitTop", "furnaceUnlitTop");
            Managers.MaterialManager.createMaterial("furnaceunlitfront", "furnaceUnlitFront", "neutral", "furnaceFront", "furnaceFront");
            Managers.MaterialManager.createMaterial("ovenunlitfront", "ovenUnlit", "neutral", "ovenFront", "ovenFront");
            Managers.MaterialManager.createMaterial("ovenlitfront", "ovenLit", "ovenLitFront", "ovenFront", "ovenFront");
            Managers.MaterialManager.createMaterial("infiniteiron", "oreIron", "neutral", "oreIron", "oreIron");
            Managers.MaterialManager.createMaterial("infiniteclay", "oreClay", "neutral", "oreClay", "oreClay");
            Managers.MaterialManager.createMaterial("infinitegypsum", "oreGypsum", "neutral", "oreGypsum", "oreGypsum");
            Managers.MaterialManager.createMaterial("infinitecoal", "oreCoal", "neutral", "oreCoal", "oreCoal");
            Managers.MaterialManager.createMaterial("infinitegold", "oreGold", "neutral", "oreGold", "oreGold");
            Managers.MaterialManager.createMaterial("infinitestone", "oreStone", "neutral", "stoneblock", "stoneblock");
            Managers.MaterialManager.createMaterial("lumberarea", "lumberArea", "neutral", "grassGeneric", "grassGeneric");
            Managers.MaterialManager.createMaterial("straw", "straw", "neutral", "straw", "straw");
            Managers.MaterialManager.createMaterial("furnacelittop", "furnaceLitTop", "furnaceLitTop", "furnaceUnlitTop", "furnaceLitTop");
            Managers.MaterialManager.createMaterial("furnacelitfront", "furnaceLitFront", "furnaceLitFront", "furnaceFront", "furnaceFront");
            Managers.MaterialManager.createMaterial("banner", "banner", "neutral", "neutral", "neutral");
            Managers.MaterialManager.createMaterial("bed", "bed", "neutral", "bed", "neutral");
            Managers.MaterialManager.createMaterial("quiverarrow", "quiverArrow", "neutral", "neutral", "neutral");
            Managers.MaterialManager.createMaterial("sappling", "sappling", "neutral", "neutral", "neutral");
            Managers.MaterialManager.createMaterial("torch", "torch", "torch", "torch", "neutral");
            Managers.MaterialManager.createMaterial("wheatwheat", "wheat", "neutral", "neutral", "neutral");
            Managers.MaterialManager.createMaterial("shop", "shop", "neutral", "shop", "shop");
            Managers.MaterialManager.createMaterial("flax", "flax", "neutral", "neutral", "neutral");
            Managers.MaterialManager.createMaterial("mint", "mint", "neutral", "mint", "mint");
            Managers.MaterialManager.createMaterial("bricks", "bricks", "neutral", "bricks", "bricks");
            Managers.MaterialManager.createMaterial("clay", "clay", "neutral", "clay", "clay");
            Managers.MaterialManager.createMaterial("grindstone", "grindstone", "neutral", "grindstone", "grindstone");
            Managers.MaterialManager.createMaterial("berrybush", "berrybush", "neutral", "berrybush", "berrybush");
            Managers.MaterialManager.createMaterial("error", "error", "neutral", "neutral", "neutral");
            Managers.MaterialManager.createMaterial("technologisttable", "technologisttable", "neutral", "neutral", "technologisttable");
        }
    }
}
