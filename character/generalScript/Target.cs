using System;
using System.Collections.Generic;
using Godot;

public partial class Target
{
    public Vector2 direction2dTarget { get; }
    public CharacterBody2D bodyTarget { get; }
    public string nameTarget { get; }

    Target(Vector2 direction2dTarget, CharacterBody2D bodyTarget, string nameTarget)
    {
        this.direction2dTarget = direction2dTarget;
        this.bodyTarget = bodyTarget;
        this.nameTarget = nameTarget;
    }
}

public partial class Targets
{
    List<Target> targets;

    public void addTarget(Target target)
    {
        targets.Add(target);
    }

    public void removeByName(string name)
    {
        Boolean flag = true;
        for (int i = 0; i < targets.Count && flag; i++)
        {
            if (targets[i].nameTarget == name)
            {
                targets.RemoveAt(i);
                flag = false;
            }
        }
    }

    public void removeByPosition(int i)
    {
        targets.RemoveAt(i);
    }
}