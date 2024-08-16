using UnityEngine;

[System.Serializable]
public abstract class BaseState<TOwner> : IState where TOwner : StateOwner
{
	protected readonly TOwner owner;
	protected readonly Animator animator;
	private int animationHash;

	protected BaseState(TOwner owner, Animator animator, AnimationClip animationClip)
	{
		this.owner = owner;
		this.animator = animator;
		SetAnimation(animationClip);
	}

	protected BaseState(TOwner owner, Animator animator)
	{
		this.owner = owner;
		this.animator = animator;
	}

	public virtual void Enter()
	{

	}

	public virtual void Exit()
	{
	}

	public virtual void FixedUpdate()
	{
	}
	public virtual void Update()
	{
	}

	public virtual void OnCollisionEnter(Collision collision)
	{
	}

	public virtual void OnCollisionExit(Collision collision)
	{
	}

	public virtual void OnTriggerEnter(Collider collider)
	{
	}

	public virtual void OnTriggerExit(Collider collider)
	{
	}

	#region Animation Handler
	protected void PlayAnimation()
	{
		if (animator != null && animationHash != 0)
		{
			animator.Play(animationHash);
		}
	}

	public void SetAnimation(AnimationClip clip)
	{
		if (clip != null)
		{
			animationHash = Animator.StringToHash(clip.name);
		}
	}
	#endregion

}
