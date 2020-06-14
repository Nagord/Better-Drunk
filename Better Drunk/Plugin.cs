using PulsarPluginLoader;

namespace Better_Drunk
{
    public class Plugin : PulsarPlugin
    {
        public override string Version => "0.2.1";

        public override string Author => "Dragon";

        public override string ShortDescription => "Makes Drunk Better";

        public override string Name => "Better Drunk";

        public override string HarmonyIdentifier()
        {
            return "Dragon.Better Drunk";
        }
    }
}
