using Godot;
using System;

public partial class click_tilemap : TileMap
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    public override void _UnhandledInput(InputEvent @event)
    {
        base._UnhandledInput(@event);

		if( @event is InputEventMouseButton mouseEvent )
		{
			if( mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left )
			{
				var clickedCell = LocalToMap( mouseEvent.Position );
				GD.Print( "Cliecked:" + clickedCell );

				SetCell( 0, clickedCell, 0);
			}
		}
    }
}
