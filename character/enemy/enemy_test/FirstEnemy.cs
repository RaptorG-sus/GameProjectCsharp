using System;
using Godot;
using Weapon;

namespace Enemy
{
    public partial class FirstEnemy : CharacterBody2D
    {
        private Vector2 direction2d;
        private Vector2 positionPlayer;

        public int coord_x { get; set; }
        public int coord_y { get; set; }

        Vector2 coord_depart;
        private CharacterBody2D Player;
        [Export]
        public Resource Stats;

        public EnemyStat enemyStat;
        public override void _Ready()
        {
            Player = GetNode<CharacterBody2D>("../../Player");
            GD.Print(Player.Position);
            if (Stats is EnemyStat enemyStat)
            {
                this.enemyStat = enemyStat;
                enemyStat.enemyTakeDamage(2);
            }
            coord_depart.X = coord_x;
            coord_depart.Y = coord_y;
            Position = coord_depart;
        }

        public override void _Process(double delta)
        {
            direction2d.X = Player.Position.X - Position.X;
            direction2d.Y = Player.Position.Y - Position.Y;
            Position += direction2d.Normalized() * 400 * (float)delta;
            MoveAndSlide();

            if (enemyStat.Health <= 0)
            {
                GD.Print("dafuk ?");
                QueueFree();
            }
        }
        private void _on_hit_box_area_entered(Area2D area)
        {
            GD.Print(enemyStat.Health);
            enemyStat.enemyTakeDamage((int)area.Get("damage"));
        }

    }
}
