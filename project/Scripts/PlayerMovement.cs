using Godot;
using System;

public partial class PlayerMovement : CharacterBody2D
{
	[ExportCategory("PlayerMovement")]
	[Export]
	private int Speed = 15;
	
	[ExportCategory("PlayerMovement")]
	[Export]
	private int JumpPower = 15;
	
	private float Gravity;
	private Vector2 velocity;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Gravity = (float)Godot.ProjectSettings.GetSetting("physics/2d/default_gravity");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{   
		Vector2 direction = Vector2.Zero;
		if( IsOnFloor() )
		{
			velocity.Y = 0.0f;
		}
		

		if (Input.IsActionPressed("move_right"))
		{
			direction.X += 1f;
		}
		if (Input.IsActionPressed("move_left"))
		{
			direction.X -= 1f;
		}

		if( Input.IsActionJustPressed("jump") && IsOnFloor() )
		{
			direction.Y -= JumpPower;
		}

        // Ground velocity
        velocity.X = direction.X * Speed;
		velocity.Y += direction.Y;

		// Gravity
		if( !IsOnFloor() )
		{
			velocity.Y += Gravity * (float)delta;
		}

		Velocity = velocity;
		MoveAndSlide();

	}
}
