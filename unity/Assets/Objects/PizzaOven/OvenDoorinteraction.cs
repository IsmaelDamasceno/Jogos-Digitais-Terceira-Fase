using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OvenDoorinteraction : MonoBehaviour, IInteractable
{
	private Animator _animator;
	private bool _aberto = false;

	public string _RotuloInteracao => "Abrir Forno";

	public void Interagir()
	{
		_aberto = !_aberto;
		_animator.SetBool("Abrir", !_aberto);
		_animator.speed = _aberto ? -1f : 1f;
		_animator.Play("OpenOvenAnimation");
	}

	void Start()
	{
		_animator = GetComponent<Animator>();
	}
}
