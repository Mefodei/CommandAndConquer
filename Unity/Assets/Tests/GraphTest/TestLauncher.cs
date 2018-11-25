using System.Collections;
using System.Collections.Generic;
using Assets.Tools.UnityTools.ActorEntityModel;
using UniStateMachine.Nodes;
using UnityEngine;

public class TestLauncher : MonoBehaviour
{

	public UniStatesGraph Graph;
	
	// Use this for initialization
	void Start () {
		Graph.Execute(new EntityObject());
	}

	private void OnDisable()
	{
		Graph.Stop();
	}
}
