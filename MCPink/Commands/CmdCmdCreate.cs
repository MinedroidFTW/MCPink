﻿/*
	Copyright 2010 MCPink Team - Written by Valek
 
    Licensed under the
	Educational Community License, Version 2.0 (the "License"); you may
	not use this file except in compliance with the License. You may
	obtain a copy of the License at
	
	http://www.osedu.org/licenses/ECL-2.0
	
	Unless required by applicable law or agreed to in writing,
	software distributed under the License is distributed on an "AS IS"
	BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express
	or implied. See the License for the specific language governing
	permissions and limitations under the License.
*/

using System;
using System.IO;
namespace MCPink
{
    public class CmdCmdCreate : Command
    {
        public override string name { get { return "cmdcreate"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Admin; } }
        public CmdCmdCreate() { }
        
        public override void Use(Player p, string message)
        {
            if (message == "" || message.IndexOf(' ') != -1)
            {
                Help(p);
                return;
            }
            else
            {
                if (File.Exists("extra/commands/source/Cmd" + message + ".cs")) { p.SendMessage("File Cmd" + message + ".cs already exists.  Choose another name."); return; }
                try
                {
                    Scripting.CreateNew(message);
                }
                catch (Exception e)
                {
                    Server.ErrorLog(e);
                    Player.SendMessage(p, "An error occurred creating the class file.");
                    return;
                }
                Player.SendMessage(p, "Successfully created a new command class.");
            }
        }

        public override void Help(Player p)
        {
            Player.SendMessage(p, "/cmdcreate <message> - Creates a dummy command class named Cmd<Message> from which you can make a new command.");
        }
    }
}