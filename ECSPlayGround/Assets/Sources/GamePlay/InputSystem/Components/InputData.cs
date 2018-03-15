public enum InputType
{
    None,
    Move,
    Atk,
}

public enum AtkId
{
    Normal,
    Skill1,
    Skill2,
    Skill3,
}

public enum FacingDirection
{
    None,
    Left,
    Right
}

public enum MoveDirection
{
    None,
    Left,
    Right
}

public static class InputParam
{
    public static string Horizontal = "Horizontal";
    public static string Vertical = "Vertical";
    public static string Atk = "mouse 0";
    
}
