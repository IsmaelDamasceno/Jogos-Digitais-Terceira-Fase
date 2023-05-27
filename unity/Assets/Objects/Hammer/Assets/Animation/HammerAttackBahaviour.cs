using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerAttackBahaviour : StateMachineBehaviour
{
	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.SetBool("Hitting", false);
		Debug.Log("Finalizando golpe");
	}
}
