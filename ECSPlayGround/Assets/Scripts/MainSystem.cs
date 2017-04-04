using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;

namespace Assets.Scripts
{
    public class MainSystem :IInitializeSystem
    {
        // always handy to keep a reference to the context 
        // we're going to be interacting with it
        readonly GameContext _context;

        public MainSystem(GameContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            // create an entity and give it a DebugMessageComponent with
            // the text "Hello World!" as its data
            _context.CreateEntity().AddDebugMessage("Hello World!");
            _context.CreateEntity().AddDebugMessage("ÁD");
            _context.CreateEntity().AddDebugMessage("ád!");
            _context.CreateEntity().AddDebugMessage("Heádrld!");
            _context.CreateEntity().AddDebugMessage("Hádrld!");
        }
    }
}
