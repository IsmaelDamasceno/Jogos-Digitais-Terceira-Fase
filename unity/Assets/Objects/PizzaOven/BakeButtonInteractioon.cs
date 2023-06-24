using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakeButtonInteractioon : MonoBehaviour, IInteractable
{
	private Animator _animator;
	private bool _ligado = false;
	private OvenController _ovenController;

	public string _RotuloInteracao => "Ligar Forno";

	public void Interagir()
	{
		float frameNormalizado = _animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
		if (frameNormalizado > 0f && frameNormalizado < 1f)
		{
			return;
		}

		if (_ovenController.Ligar(!_ligado))
		{
			_ligado = !_ligado;
			_animator.SetFloat("AnimSpd", 1f);
			_animator.SetBool("Ligado", _ligado);
		}
	}

	void Start()
	{
		_animator = GetComponent<Animator>();
		_ovenController = transform.parent.parent.GetComponent<OvenController>();
	}
}
