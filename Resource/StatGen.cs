using System;
using System.ComponentModel.DataAnnotations;
using Godot;

namespace Stats
{
    [GlobalClass]
    public partial class StatGen : Resource
    {
        [ExportGroup("Health property")]
        [Export(PropertyHint.Range, "0,500,or_greater")] public int health { get; set; }
        [Export(PropertyHint.Range, "0,500,or_greater")] public int healthRegen { get; set; }
        [Export(PropertyHint.Range, "-100,100")] public double lifeSteale { get; set; }



        [ExportGroup("Damage property")]
        [Export(PropertyHint.Range, "1,500,or_greater")] public int damageBase { get; set; }
        [Export(PropertyHint.Range, "0,500,or_greater")] public int damageProximity { get; set; }
        [Export(PropertyHint.Range, "0,500,or_greater")] public int damageDistant { get; set; }
        [Export(PropertyHint.Range, "1,500,or_greater")] public int knockback { get; set; }


        [ExportGroup("Speed property")]
        [Export(PropertyHint.Range, "1,400,")] public int speed { get; set; }
        [Export(PropertyHint.Range, "1,500,or_greater")] public double attackSpeed { get; set; }
        [Export(PropertyHint.Range, "1,500,or_greater")] public double projectileSpeed { get; set; }
        [Export(PropertyHint.Range, "0,500,or_greater")] public int defense { get; set; }




        [ExportGroup("Other property")]
        [Export(PropertyHint.Range, "0,500,or_greater")] public double aoe { get; set; }
        [Export(PropertyHint.Range, "0.1,500,or_greater")] public double size { get; set; }
        [Export(PropertyHint.Range, "0,100")] public double escape { get; set; }


        [ExportGroup("Critic property")]
        [Export(PropertyHint.Range, "0,100")] public double critChance { get; set; }
        [Export(PropertyHint.Range, "0,500,or_greater")] public double critDamage { get; set; }

        public void doDamageDistant(StatGen target)
        {
            if (GD.Randf() * 100 <= critChance)
            {
                target.health -= (int)((this.damageBase + this.damageDistant) * this.critDamage);
                this.health += (int)((this.damageBase + this.damageDistant) * this.critDamage * (lifeSteale / 100));
            }
            else
            {
                target.health -= this.damageBase + this.damageDistant;
                this.health += (int)((this.damageBase + this.damageDistant) * (lifeSteale/100));
            }
        }

        public void doDamageNextTo(StatGen target)
        {
            if (GD.Randf() * 100 <= critChance)
            {
                target.health -= (int)((this.damageBase + this.damageProximity) * this.critDamage);
                this.health += (int)((this.damageBase + this.damageProximity) * this.critDamage * (lifeSteale / 100));
            }
            else
            {
                target.health -= this.damageBase + this.damageProximity;
                this.health += (int)((this.damageBase + this.damageProximity) * (lifeSteale/100));
            }


        }
    }
}