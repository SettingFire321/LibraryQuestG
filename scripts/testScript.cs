using Godot;
using System;

public partial class testScript : Node
{
	public int Speed { get; set; } = 400;
	private static Vector2 GlobalPosition = new Vector2(0,0);
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {

		Console.WriteLine("YOOOOOOOO HERE I IS!!!!");

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("Up")) {
			
			GlobalPosition += new Vector2(5,0);
			
		}
		
		if (Input.IsActionPressed("Down")) {
			
			GlobalPosition += new Vector2(-5,0);
			
		}
		
		if (Input.IsActionPressed("Left")) {
			
			GlobalPosition += new Vector2(0,-5);
			
		}
		
		if (Input.IsActionPressed("Right")) {
			
			GlobalPosition += new Vector2(0,5);
			
		}
	}
}
