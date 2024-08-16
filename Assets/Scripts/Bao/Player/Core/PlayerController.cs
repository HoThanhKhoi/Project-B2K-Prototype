using System.Collections.Generic;
using UnityEngine;

public class PlayerController : StateOwner
{
	private Rigidbody rb;
	private Animator anim;

	[SerializeField] private AnimationClip idleClip;
	[SerializeField] private AnimationClip jumpClip;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
	}

	public void Jump()
	{
		rb.AddForce(Vector3.up * 10f, ForceMode.Impulse);
	}

	protected override void SetUpStateMachine()
	{
		IdleState idleState = new IdleState(this, anim, idleClip);
		JumpState jumpState = new JumpState(this, anim, jumpClip);

		At(idleState, jumpState, new FuncPredicate(() => Input.GetButtonDown("Jump")));

		stateMachine.SetState(idleState);
	}

}
