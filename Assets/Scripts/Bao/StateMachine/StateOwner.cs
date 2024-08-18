using UnityEngine;

public abstract class StateOwner : MonoBehaviour
{
	public Animator anim { get; set; }

	protected virtual void Start()
	{
		anim = GetComponent<Animator>();
	}
}
