using UnityEngine;

public class IdleState : PlayerState
{
	public IdleState(PlayerController owner, Animator animator, AnimationClip animationClip) : base(owner, animator, animationClip)
	{
	}

	public override void Enter()
	{
		base.Enter();
	}
}
