using Godot;
using System;

namespace Weapon
{
    [GlobalClass]
    public partial class Fire : Resource
    {
        [Export]
        public int burnDamage { get; set; } = 2;

        [Export]
        public int burnTimer { get; set; } = 5;

        public string elementName { get; } = "Fire";
    }
}
