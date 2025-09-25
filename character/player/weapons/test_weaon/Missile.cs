using Godot;

namespace Weapon
{
    public partial class Missile : Area2D
    {

        [Export]
        public Vector2 direction2d { get; set; }

        [Export]
        public Vector2 startPosition { get; set; }

        [Export]
        public Resource Stats;

        private MissileStats missileStats;
        private Timer timer;
        
        public int damage { get; set; }
        public override void _Ready()
        {
            base._Ready();
            timer = GetNode<Timer>("Timer");
            Position = startPosition;
            if (Stats is MissileStats missileStats)
            {
                this.missileStats = missileStats;
                this.damage = missileStats.damage;
            }
        }

        private void _on_timer_timeout()
        {
            missileStats.ApplyElementEffect();
            QueueFree();
        }

        public override void _Process(double delta)
        {
            Position += direction2d.Normalized() * (float)delta * 300;
        }
    }
}

