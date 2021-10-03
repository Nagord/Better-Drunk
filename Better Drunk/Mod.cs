using PulsarModLoader;

namespace Better_Drunk
{
    public class Mod : PulsarMod
    {
        public override string Version => "0.2.3";

        public override string Author => "Dragon";

        public override string ShortDescription => "Makes Drunk Better";

        public override string Name => "Better Drunk";

        public override string HarmonyIdentifier()
        {
            return "Dragon.Better Drunk";
        }
    }
}
