using Godot;
using System;

public partial class World01 : Node2D
{

    [Export]
    public Timer timerEnemy;

    [Export]
    public Node2D enemySpawnNode;
    public int timeEnemy { get; set; }

    public int numberEnemy { get; set; }

    public int coord_x;

    public int coord_y;

    public PackedScene enemy;
    public override void _Ready()
    {
        base._Ready();
        enemySpawnNode = GetNode<Node2D>("Character/Enemy");
        timerEnemy = GetNode<Timer>("TimerEnemy");
        enemy = GD.Load<PackedScene>("res://character/enemy/enemy_test/first_enemy.tscn");
        spawnEnemy(enemy, 6);
    }


    public override void _Process(double delta)
    {
        base._Process(delta);
    }

    public void spawnEnemy(PackedScene Enemy, int numberEnemy)
    
    {
        
        for (int i = 0; i < numberEnemy; i++)
        {
            GD.Print(numberEnemy);
            var instance = Enemy.Instantiate();
            coord_x = ((int)GD.Randi() % 3001);
            coord_y = ((int)GD.Randi() % 1401);
            instance.Set("coord_y", coord_y);
            instance.Set("coord_x", coord_x);
            GD.Print(coord_x);
            GD.Print(coord_y);
            enemySpawnNode.AddChild(instance);
        }
    }
}
