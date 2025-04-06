using Godot;
using System;
[Tool]
public partial class ValueGenerator : Node {
    [Export] GraphMain graph;
    [Export(PropertyHint.Range, "0,1,")] private float target;
    [Export] private float totalValueModifier;
    [Export] private float randomScaleModifier;

    public override void _Process(double delta) {
        base._Process(delta);
        if (graph == null)
            return;

        graph.AddDataToEnd(generateValue(), 0);
        graph.AddDataToEnd(generateValue() * .5f, 1);
    }
    private float generateValue() {
        var rng = new RandomNumberGenerator();

        return totalValueModifier * (target + randomScaleModifier * rng.Randf());
    }

}
