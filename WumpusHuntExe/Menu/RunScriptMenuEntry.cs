using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WumpusHunt.Models;
using WumpusHuntExe.Scripting;

namespace WumpusHuntExe.Menu
{
    class RunScriptMenuEntry : IMenuEntry
    {
        private PythonEngine _engine;

        public RunScriptMenuEntry(Game game)
        {
            _engine = new PythonEngine(game);
        }
        public string Title { get { return "Run script"; } }
        public int Weight { get { return 0; } }
        public void Execute(Game game)
        {
            Console.WriteLine("Please enter path to script. Leave empty to cancel");
            var path = Console.ReadLine();
            if(string.IsNullOrEmpty(path))
            {
                return;
            }
            _engine.RunScript(path);
        }
    }
}
