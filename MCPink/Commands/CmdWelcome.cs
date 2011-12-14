using System;

namespace MCPink
{
    public class CmdWelcome : Command
    {
        public override string name { get { return "welcome"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Guest; } }
        public CmdWelcome() { }
        public override void Use(Player p, string message)
        {
            if (message == "")
            {
                Help(p);
				return;
            }
            Player player1 = Player.Find(message);
            if (player1 == null || player1.hidden == true)
            {
                Player.SendMessage(p, "Could not find player specified.");
				return;
            }

			string giver = (p == null) ? "The Console" : p.name;
			string color = (p == null) ? "" : p.color;
            Player.SendMessage(player1, giver + " %dJust threw confetti in the air to welcome you.");
            Player.GlobalMessage(color + giver + " " + Server.DefaultColor + "%djust threw confetti in the air to welcome " + player1.color + player1.name);
        }

        // This one controls what happens when you use /help [commandname].
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/welcome <player> - Welcomes the player :D");
        }
    }
}