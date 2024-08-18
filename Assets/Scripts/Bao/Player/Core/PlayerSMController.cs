using UnityEngine;

public class PlayerSMController : StateMachineController<PlayerController>
{
	[SerializeField] private AnimationClip idleClip;
	[SerializeField] private AnimationClip jumpClip;
	protected override void SetUpStateMachine()
	{
		IdleState idleState = new IdleState(owner, owner.anim, idleClip);
		JumpState jumpState = new JumpState(owner, owner.anim, jumpClip);

		At(idleState, jumpState, new FuncPredicate(() => Input.GetButtonDown("Jump")));

		stateMachine.SetState(idleState);
	}
}
