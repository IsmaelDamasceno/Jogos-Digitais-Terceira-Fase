using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OvenDoorinteraction : MonoBehaviour, IInteractable
{
	private Animator _animator;
	private bool _aberto = false;
	private OvenController _ovenController;

	public string _RotuloInteracao => "Abrir Forno";

	public void Interagir()
	{
		float frameNormalizado = _animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
		if (frameNormalizado > 0f && frameNormalizado < 1f)
		{
			return;
		}

		if (_ovenController.Abrir(!_aberto)) {
			_aberto = !_aberto;
			_animator.SetFloat("AnimSpd", 1f);
			_animator.SetBool("Aberto", _aberto);
		}
	}

	void Start()
	{
		_animator = GetComponent<Animator>();
		_ovenController = transform.parent.GetComponent<OvenController>();
	}

}
