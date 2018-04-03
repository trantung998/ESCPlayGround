using Sources.Tools;

namespace Sources.GamePlay.Player.Scripts
{
    public class CharacterAbilityManager : 
        Singleton<CharacterAbilityManager>
    {
        private string databasePath = "";
        private AbilityDatabase database;
        
        protected CharacterAbilityManager()
        {
        }

        public void WarmUp()
        {
            
        }

        private void Start()
        {
            InitData();
        }

        private void InitData()
        {
            database = Utilities.LoadScriptableObject<AbilityDatabase>(databasePath);
            
        }
        
        
    }
}