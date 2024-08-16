using UnityEngine;

public class PlayerState : BaseState<PlayerController>
{
	public PlayerState(PlayerController owner, Animator animator, AnimationClip animationClip) : base(owner, animator, animationClip)
	{
	}
}
