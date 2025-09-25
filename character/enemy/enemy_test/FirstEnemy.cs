using Godot;

namespace Enemy
{
    public partial class FirstEnemy : CharacterBody2D
    {
        private Vector2 direction2d;
        private Vector2 positionPlayer;

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
                GD.Print(enemyStat.Health);
                this.enemyStat = enemyStat;
                enemyStat.enemyTakeDamage(2);
            }
        }

        public override void _Process(double delta)
        {
            direction2d.X = Player.Position.X - Position.X;
            direction2d.Y = Player.Position.Y - Position.Y;
            Position += direction2d.Normalized() * 400 * (float)delta;
            MoveAndSlide();
            if (Input.IsActionJustPressed("shoot"))
            {
                enemyStat.enemyTakeDamage(2);
            }
        }

    }
}
