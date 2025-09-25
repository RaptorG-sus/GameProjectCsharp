using Godot;
using System;

namespace Weapon
{
    [GlobalClass]
    public partial class Water : Resource
    {
        [Export]
        public int kbModifier { get; set; } = 2;

        public string elementName { get; } = "Water";
    }
}
