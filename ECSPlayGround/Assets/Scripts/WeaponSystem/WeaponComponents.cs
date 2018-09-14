using System.Collections.Generic;
using Entitas;

[Game]
public class WeaponIdComponent : IComponent
{
    public int value;
}

[Game]
public class DamageComponent : IComponent
{
    public float value;
}

[Game]
public class HpComponent : IComponent
{
    public float value;
}

[Game]
public class AtkSpeedComponent : IComponent
{
    public float value;
}

[Game]
public class CollsionsComponent : IComponent
{
    public List<Entity> listOther;
    public bool isInitialized;
}

public enum BulletTrajectory
{
    None,
    Linear,
    Circle
}

[Game]
public class BulletConfigs : IComponent
{
    public BulletTrajectory Trajectory;
    public int NumberBullet;
    public float DelayShot;
    public float ShotAngel;
    public float BulletSpeed;
}