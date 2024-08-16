using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
	private StateNode currentNode;
	private readonly Dictionary<Type, StateNode> nodeDictionary = new Dictionary<Type, StateNode>(); // Store all nodes and the state attached to it
	private readonly HashSet<ITransition> anyTransitions = new HashSet<ITransition>(); //If any state meet the condition of one of these transitions, immediatly change state

	public void Update()
	{
		//Get transition that meet the condition, if not the value is null
		ITransition transition = GetTransition();

		if (transition != null)
		{
			ChangeState(transition.To);
		}

		currentNode.State?.Update();
	}

	public void FixedUpdate()
	{
		currentNode.State?.FixedUpdate();
	}
	public void OnTriggerEnter(Collider collider)
	{
		currentNode.State?.OnTriggerEnter(collider);
	}

	public void OnTriggerExit(Collider collider)
	{
		currentNode.State?.OnTriggerExit(collider);
	}

	public void OnCollisionEnter(Collision collision)
	{
		currentNode.State.OnCollisionEnter(collision);
	}

	public void OnCollisionExit(Collision collision)
	{
		currentNode.State?.OnCollisionExit(collision);
	}

	public void SetState(IState state)
	{
		currentNode = nodeDictionary[state.GetType()];
		currentNode.State?.Enter();
	}

	

	//Change from one state to new state when condition is fulfill
	public void AddTransition(IState from, IState to, IPredicate condition)
	{
		//Add transition to the from state * the purpose of GetOrAddNode() is to make sure the node attach to the state is exist
		GetOrAddNode(from).AddTransition(GetOrAddNode(to).State, condition);
	}

	//Change to new state when condition is fulfill for any state
	public void AddAnyTransition(IState to, IPredicate condition)
	{
		anyTransitions.Add(new Transition(GetOrAddNode(to).State, condition));
	}


	private void ChangeState(IState state)
	{
		if (state == currentNode.State)
		{
			return;
		}

		IState prevState = currentNode.State;
		IState nextState = nodeDictionary[state.GetType()].State;

		prevState?.Exit();
		nextState?.Enter();

		currentNode = GetOrAddNode(state);
	}

	//Loop all transitions and find the one that meet the condition, if not, the value is null
	private ITransition GetTransition()
	{
		//If any transition in the anyTransition list meet the condition, get that transition
		foreach (ITransition transition in anyTransitions)
		{
			if (transition.Condition.Evaluate())
			{
				return transition;
			}
		}

		//If any transition in the current state meet the condition, get that transition
		foreach (ITransition transition in currentNode.Transitions)
		{
			if (transition.Condition.Evaluate())
			{
				return transition;
			}
		}

		return null;
	}

	//Return the node attached to the state, if the node not exist, create a new one
	private StateNode GetOrAddNode(IState state)
	{
		StateNode node = nodeDictionary.GetValueOrDefault(state.GetType());

		if (node == null)
		{
			node = new StateNode(state);
			nodeDictionary.Add(state.GetType(), node);
		}

		return node;
	}

	private class StateNode
	{
		public IState State { get; }
		public HashSet<ITransition> Transitions { get; }
		public StateNode(IState state)
		{
			State = state;
			Transitions = new HashSet<ITransition>();
		}

		public void AddTransition(IState to, IPredicate condition)
		{
			Transitions.Add(new Transition(to, condition));
		}
	}
}
