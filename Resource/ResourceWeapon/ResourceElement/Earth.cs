using Godot;
using System;

namespace Weapon
{
    [GlobalClass]
    public partial class Earth : Resource
    {
        [Export]
        public double lifeStealing { get; set; } = 0.2;

        public string elementName { get; } = "Earth";
    }
}
