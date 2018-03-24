
public enum PlayerAnimationState
{
    None,
    Idle,
    Move,
    Jump,
    Atk,
}

public enum CharacterState
{
    None,
    Normal,
    Death,
    MovementControled,
}

public enum CharacterMovementState
{
    Run,
    KnockBack,
    Slow,
    Root,
    Freeze,
    Pull,
    Fly,
    Jump,
    Fall,
    Dash,
}

public enum CharacterFiniteState
{
    None,
    Idle,
    Move,
    Jump,
    Atk,
    Die,
    KnockBack,
    Taunt,
    BeHit,
    CastSkill,
    Stun,
}

public class GamePlayStatic
{
    public static string ANIMATION_IDLE = "Idle";
    public static string ANIMATION_WALK = "Move";
    public static string ANIMATION_ATK = "Atk1";
    public static string ANIMATION_DIE = "Die";
    public static string ANIMATION_VICTORY = "Victory";
    public static string ANIMATION_STUN = "Stun";
}
