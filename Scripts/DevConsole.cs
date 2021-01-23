using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
namespace Console
{
    public abstract class ConsoleCmd
    {
        public abstract string Name { get; protected set; }
        public abstract string Command { get; protected set; }
        public abstract string Description { get; protected set; }
        public abstract string Help { get; protected set; }
        public void AddCmdToConsole() {
            string addMessage = " command has been added to the console";
            DevConsole.AddCmdsToConsole(Command, this);
            Debug.Log(Name+addMessage);
        }

        public abstract void RunCommand(string[] args);
    }
    public class DevConsole : MonoBehaviour
    {
        public static DevConsole Instance { get; private set; }
        public static Dictionary<string, ConsoleCmd> Cmds { get; private set; }
        [Header("UICOMPONENTS")]
        public Canvas ConsoleCanvas;
        public Text ConsoleText;
        public Text inputText;
        public InputField consoleInput;

        private void Awake()
        {
            if (Instance != null) {
                return;
            }
            Instance = this;
            Cmds = new Dictionary<string, ConsoleCmd>();
        }
        private void Start()
        {
            ConsoleCanvas.gameObject.SetActive(true);
            Createcmds();
        }
        private void OnEnable()
        {
            Application.logMessageReceived += HandleLog;
        }
        private void OnDisable()
        {
            Application.logMessageReceived -= HandleLog;
        }
        void HandleLog(string s,string stackTrace,LogType los) { 
        string msg1 = "[" + los.ToString() + "] " + s;
            AddMsgToConsole(msg1);

        }
        private void Createcmds() {
            CmdQuit.Createcmds();
            CmdCube.Createcmds();
            clearCnle.Createcmds();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) {
                ConsoleCanvas.gameObject.SetActive(!ConsoleCanvas.gameObject.activeInHierarchy);
            }
            if (ConsoleCanvas.gameObject.activeInHierarchy) {
                if (Input.GetKeyDown(KeyCode.Return)) {
                    if (inputText.text.CompareTo("")!=0) {
                        AddMsgToConsole(inputText.text);

                        ParseInput(inputText.text);
                        inputText.text = "";
                    }
                }
            }
        }
        public static void  AddCmdsToConsole(string _name, ConsoleCmd c) {
            if (!Cmds.ContainsKey(_name)) {
                Cmds.Add(_name, c);
            }
        
        }
         void  AddMsgToConsole(string msg) {
            ConsoleText.text +=  msg +"\n";
        }
        public void ClearConsole()
        {
            ConsoleText.text = "";
        }
        void ParseInput(string input) {
            string[] _input = input.Split(' ');
            Debug.Log(_input[0]);
            if (_input.Length == 0 || _input == null) {
                Debug.LogWarning(1);
                Debug.LogWarning("Command not recognized.");
                return;
            }
            if (!Cmds.ContainsKey(_input[0]))
            {
                Debug.LogWarning(2);
                Debug.LogWarning("Command not recognized.");
                return;
            }

            else {
                List<string> args = _input.ToList();
                
                args.RemoveAt(0);
                if (args.Contains("-help"))
                {
                    AddMsgToConsole("==============================");
                    AddMsgToConsole(Cmds[_input[0]].Description);
                    AddMsgToConsole("------------------------------");
                    AddMsgToConsole(Cmds[_input[0]].Help);
                    AddMsgToConsole("==============================");

                    return;
                }
                Cmds[_input[0]].RunCommand(args.ToArray());
                
            }

        }
    }
}
