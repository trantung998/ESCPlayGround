public enum EffectType
{
    None, 
    Slow,
    Stun,
}

public class EffectData
{
    public string id;
    public EffectType type;
    public float duration;
    public float value;
    
}
