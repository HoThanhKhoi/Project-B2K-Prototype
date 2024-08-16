using UnityEngine;

public interface IState
{
	void Enter();
	void Exit();
	void Update();
	void FixedUpdate();
	void OnTriggerEnter(Collider collider);
	void OnTriggerExit(Collider collider);
	void OnCollisionEnter(Collision collision);
	void OnCollisionExit(Collision collision);
}
