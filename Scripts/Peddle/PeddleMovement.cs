using Godot;
using System;

public class PeddleMovement : KinematicBody2D
{
    [Export] 
    private int speed = 200;
    [Export]
    private int player = 1;

    private Vector2 _velocity;

    private void SetInput()
    {
        _velocity = new Vector2();

        if (Input.IsActionPressed(string.Format("up_{0}", player)))
            _velocity.y -= 1;

        if (Input.IsActionPressed(string.Format("down_{0}", player)))
            _velocity.y += 1;

        _velocity = _velocity.Normalized() * speed;
    }

    public override void _PhysicsProcess(float delta)
    {
        base._PhysicsProcess(delta);
        
        SetInput();
        _velocity = MoveAndSlide(_velocity);
    }
}