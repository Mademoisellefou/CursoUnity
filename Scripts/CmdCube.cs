using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
namespace Console {

    public class CmdCube : ConsoleCmd
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }

        public CmdCube()
        {
            Name = "Cube";
            Command = "Cube";
            Description = "Cube the application";
            Help = Help = "Options: \n" +
                    "-x=<value> where <value is the integer value of the x coordinate" +
                    "-y=<value> where <value is the integer value of the y coordinate" +
                    "-z=<value> where <value is the integer value of the z coordinate";

            AddCmdToConsole();
        }
        public static CmdCube Createcmds()
        {
            return new CmdCube();
        }
        public override void RunCommand(string[] args)
        {
            int x = 0, y = 0, z = 0;
            for (int i = 0; i < args.Length; i++)
            {

                string _arg = args[i];
                string[] argSplit = Regex.Split(_arg, @"\=");
                switch (argSplit[0])
                {
                    case "-x":
                        x = int.Parse(argSplit[1]);
                        break;
                    case "-y":
                        y = int.Parse(argSplit[1]);
                        break;
                    case "-z":
                        z = int.Parse(argSplit[1]);
                        break;
                    default:
                        break;
                }
            }
            GameObject a = (GameObject)Resources.Load("Cube");
            GameObject b = MonoBehaviour.Instantiate(a, Vector3.one, Quaternion.identity);
        }

    }

}
