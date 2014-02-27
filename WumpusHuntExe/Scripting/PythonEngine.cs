using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using IronPython.Hosting;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using WumpusHunt.Models;

namespace WumpusHuntExe.Scripting
{
    public class PythonEngine
    {
        private ScriptEngine _engine;
        private Game _game;

        public PythonEngine(Game game)
        {
            _engine = Python.CreateEngine();
            var searchPaths = _engine.GetSearchPaths().ToList();
            var pythonPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Scripting", "PythonIncludes");
            searchPaths.Add(pythonPath);
            _engine.SetSearchPaths(searchPaths);
            _engine.Runtime.Globals.SetVariable("WumpusGame", game);
            _game = game;
        }

        public void RunScript(string path)
        {
            RunStatement(File.ReadAllText(path));
        }

        public void RunStatement(string code)
        {
            _engine.Execute(code);
        }
    }
}
