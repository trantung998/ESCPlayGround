namespace GamePlay.GameEvents
{
    public class GameEvents
    {
        
    }

    public class SetPlayerIdEvent
    {
        public string playerId;

        public SetPlayerIdEvent(string playerId)
        {
            this.playerId = playerId;
        }
    }
}