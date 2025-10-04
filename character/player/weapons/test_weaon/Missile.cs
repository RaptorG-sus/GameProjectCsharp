using System.Runtime.InteropServices.Swift;
using System.Security.Cryptography.X509Certificates;
using Enemy;
using Godot;
using Stats;

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
        
        public int totalDamage { get; set; }

        public StatGen playerStat;

        CharacterBody2D player;
        public override void _Ready()
        {
            base._Ready();
            timer = GetNode<Timer>("Timer");
            Position = startPosition;
            player = this.GetNode<CharacterBody2D>("../../../Character/Player");
            playerStat = (StatGen)player.Get("playerStat"); 
            
            if (Stats is MissileStats missileStats)
            {
                this.missileStats = missileStats;
                this.totalDamage = missileStats.damageBase + (int)player.Get("damageDistant");
            }
        }

        private void _on_body_entered(CharacterBody2D body)
        {
            playerStat.doDamageDistant((StatGen)body.Get("enemyStat"));
            body.Position = new Vector2(body.Position.X + direction2d.X * 100, body.Position.Y + direction2d.Y * 100);
            QueueFree();
        }

        private void _on_timer_timeout()
        {
            QueueFree();
        }

        public override void _Process(double delta)
        {
            Position += direction2d.Normalized() * (float)delta * 300;
        }
    }
}

