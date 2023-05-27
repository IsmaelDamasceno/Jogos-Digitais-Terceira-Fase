using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaSmash : MonoBehaviour
{
    private Animator _animator;

    [SerializeField]
    private float _tempo = 0f;

    public string _RotuloInteracao => "Bater na pizza";
	public void Interagir()
	{
		_tempo += 0.1f;
		_tempo = Math.Clamp(_tempo, 0f, 1f);
		_animator.Play("Flatten", -1, _tempo);
	}

	void Start()
    {
        _animator = GetComponent<Animator>();
    }
}
