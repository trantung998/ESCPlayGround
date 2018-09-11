using Entitas;

public interface IViewControler
{
    Vector2D Position { get; set; }
    Vector2D Scale { get; set; }
    bool Active { get; set; }
    void InitializeView(Contexts contexts, IEntity Entity);
    void DestroyView(bool usePool);
}