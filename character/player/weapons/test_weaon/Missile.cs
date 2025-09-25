using Godot;


public partial class Missile : Area2D
{

    [Export]
    public Vector2 direction2d { get; set; }

    [Export]
    public Vector2 startPosition { get; set; }

    private Timer timer;
    public override void _Ready()
    {
        base._Ready();
        timer = GetNode<Timer>("Timer");
        Position = startPosition; 
    }

    private void _on_timer_timeout()
    {
        GD.Print("timeout :)");
        QueueFree();
    }

    public override void _Process(double delta)
    {
        Position += direction2d.Normalized() * (float)delta * 300;
    }
}

