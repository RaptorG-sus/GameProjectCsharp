using Godot;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Weapon
{
    public enum ElementsType
    {
        None,
        Fire,
        Water,
        Earth,
        Air,
        Lightning
    }
    [GlobalClass]
    public partial class MissileStats : Resource
    {
        [Export]
        public int damageBase { get; set; }

        [Export]
        public int critChance { get; set; }

        [Export]
        public double critDamage { get; set; }

        [Export(PropertyHint.ResourceType, "Water,Fire,Lightning,Earth")]
        public Resource element { get; set; } = null;

        [Export]
        public double knockback { get; set; }


        /*public void ApplyElementEffect()
        {
            switch (element)
            {
                case ElementsType.Fire:
                    GD.Print("Feu");
                    break;
                case ElementsType.Water:
                    GD.Print("Water");
                    break;
                default:
                    break;
            }
        }*/

        public void ApplyElementEffect()
        {
            if (element != null)
            {
                GD.Print(element.Get("elementName"));
            }
        }
    }
    
}