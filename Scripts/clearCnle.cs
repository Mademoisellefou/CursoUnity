using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Console { 
    public class clearCnle :ConsoleCmd
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }

        public clearCnle()
        {
            Name = "Clear";
            Command = "clear";
            Description = "Erases the console text.";
            Help = "Use this command to start a fresh console.";
            AddCmdToConsole();
        }
        public static clearCnle Createcmds()
        {
            return new clearCnle();
        }


        public override void RunCommand(string[] args) {
            DevConsole.Instance.ClearConsole();
        }

    }


}

