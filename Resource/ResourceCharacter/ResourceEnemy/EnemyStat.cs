using Godot;
using System;
using System.ComponentModel.Design;
namespace Enemy
{
    [GlobalClass]
    public partial class EnemyStat : Resource
    {
        [Export]
        public int Health { get; set; }

        [Export]
        public Resource Specialite { get; set; }

        [Export]
        public int Damage { get; set; }

        public EnemyStat()
        {
            this.Health = 10;
            this.Damage = 1;
            this.Specialite = null;
        }

        public EnemyStat(int Health, int Damage)
        {
            this.Health = Health;
            this.Damage = Damage;
        }


        public void enemyTakeDamage(int damageTake)
        {
            this.Health -= damageTake;
            GD.Print(this.Health);
        }
    }
}
