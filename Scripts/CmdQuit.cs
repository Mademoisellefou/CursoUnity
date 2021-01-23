using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Console {


    public class CmdQuit : ConsoleCmd
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }

        public CmdQuit() {
            Name = "Quit";
            Command = "quit";
            Description = "Quits the application";
            Help = "Use this command with no arguments to force Unity to quit!";
            AddCmdToConsole();
        }
        public static CmdQuit   Createcmds() {
            return  new CmdQuit();
        }
        public override void RunCommand(string[] args) {
            if (Application.isEditor)
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
            }
            else {
                Application.Quit();
            }
        }
    }


}
