using Godot;
using System;
public partial class Player : CharacterBody2D
{
    Vector2 direction2d = Vector2.Zero;
    Vector2 direction2dForShoot;
    private Label label;

    private Node2D shootNode;

    private Shoot _shoot;
    public override void _Input(InputEvent @event)
    {
        direction2d = Input.GetVector("gauche", "droite", "haut", "bas");
        direction2d.Normalized();
    }

    public override void _Ready()
    {
        label = GetNode<Label>("Label");
        shootNode = GetNode<Node2D>("../../Projectile/PlayerProjectile");
        PackedScene ammo = GD.Load<PackedScene>("res://character/player/weapons/test_weaon/missile.tscn");
        _shoot = new Shoot(ammo);

    }

    public override void _Process(double delta)
    {
        Position += direction2d * (float)delta * 200;
        Position = new Vector2(
            x: Mathf.Clamp(Position.X, 0, 3000),
            y: Mathf.Clamp(Position.Y, 0, 1400)
        );
        MoveAndSlide();

        label.Text = "X = " + Position.X + "\n Y = " + Position.Y;

        if (Input.IsActionJustPressed("shoot"))
        {
            _shoot.Fire(Vector2.Left, shootNode, Position);
        }
    }

    private void _on_range_player_area_body_entered(Node2D body)
    {
        direction2dForShoot.X = body.Position.X - Position.X;
        direction2dForShoot.Y = body.Position.Y - Position.Y;
        _shoot.Fire(direction2dForShoot, shootNode, Position);
    }
}



public partial class Shoot : Area2D
{
    PackedScene ammo;
    public Shoot(PackedScene ammo)
    {
        this.ammo = ammo;
    }


    public void Fire(Vector2 direction2d, Node2D shoot, Vector2 startPosition)
    {
        var instance = this.ammo.Instantiate();
        instance.Set("startPosition", startPosition);
        instance.Set("direction2d", direction2d);
        shoot.AddChild(instance);
    }
}