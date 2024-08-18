using UnityEngine;

public abstract class StateMachineController<TOwner> : MonoBehaviour where TOwner : StateOwner
{
	protected StateMachine stateMachine;
	protected TOwner owner;

	//Serialize the AnimationClips inside the childen

	protected virtual void Awake()
	{
		stateMachine = new StateMachine();
		owner = GetComponent<TOwner>();

		SetUpStateMachine();
	}

	protected abstract void SetUpStateMachine(); //Set up states => Set up transitions => Set up initial state

	protected void At(IState from, IState to, IPredicate condition)
	{
		stateMachine.AddTransition(from, to, condition);
	}
	protected void Any(IState to, IPredicate condition) => stateMachine.AddAnyTransition(to, condition);
	protected virtual void Update() => stateMachine.Update();
	protected virtual void FixedUpdate() => stateMachine.FixedUpdate();
	protected virtual void OnTriggerEnter(Collider collider) => stateMachine.OnTriggerEnter(collider);
	protected virtual void OnTriggerExit(Collider collider) => stateMachine.OnTriggerExit(collider);
	protected virtual void OnCollisionEnter(Collision collision) => stateMachine.OnCollisionEnter(collision);
	protected virtual void OnCollisionExit(Collision collision) => stateMachine.OnCollisionExit(collision);
}
