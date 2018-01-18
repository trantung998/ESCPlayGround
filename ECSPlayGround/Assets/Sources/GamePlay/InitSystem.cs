using Entitas;

namespace Sources.GamePlay
{
    public class InitSystem : IInitializeSystem
    {
        public void Initialize()
        {
            InitMap();
            PreparePlayer();
        }

        private void PreparePlayer()
        {
            //instatiate prefab
            //add component
        }
        
        private void InitMap()
        {
            
        }
    }
}