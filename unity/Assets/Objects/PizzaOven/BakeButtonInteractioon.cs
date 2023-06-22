using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakeButtonInteractioon : MonoBehaviour, IInteractable
{
	private Animator _animator;
	private bool _aberto = false;

	public string _RotuloInteracao => "Ligar Forno";

	public void Interagir()
	{
		float frameNormalizado = _animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
		if (frameNormalizado > 0f && frameNormalizado < 1f)
		{
			return;
		}

		_aberto = !_aberto;
		_animator.SetFloat("AnimSpd", 1f);
		_animator.SetBool("Ligado", _aberto);
	}

	void Start()
	{
		_animator = GetComponent<Animator>();
	}
}
