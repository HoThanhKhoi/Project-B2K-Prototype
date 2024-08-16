using UnityEngine;

public class JumpState : PlayerState
{
	public JumpState(PlayerController owner, Animator animator, AnimationClip animationClip) : base(owner, animator, animationClip)
	{
	}
	public override void Enter()
	{
		base.Enter();

		owner.Jump();
	}
}
