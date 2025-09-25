using Godot;
using System;

namespace Weapon
{
    [GlobalClass]
    public partial class Lightning : Resource
    {
        [Export]
        public int chainDamage { get; set; } = 2;

        [Export]
        public int chainRange { get; set; } = 100;

        public string elementName { get; } = "Lightning";
    }
}
