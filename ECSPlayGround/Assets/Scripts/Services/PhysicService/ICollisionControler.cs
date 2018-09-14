using Entitas;

public interface ICollisionControler
{
    void Init(Contexts contexts, Entity entity);

    void OnCollision(Entity other);
}