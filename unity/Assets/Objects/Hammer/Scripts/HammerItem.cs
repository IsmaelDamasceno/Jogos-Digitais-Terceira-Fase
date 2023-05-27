using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TreeEditor;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class HammerItem : MonoBehaviour, IItem
{

    private Animator _animator;
    private Rigidbody _rigidbody;
    private MeshCollider _collider;

	void Start()
	{
		_animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<MeshCollider>();
	}
	void Update()
	{

	}

	public void CliquePrincipal()
    {
        if (!_animator.GetBool("Hitting"))
        {
            _animator.SetBool("Hitting", true);
        }
    }
    public void CliqueSecundario()
    {

    }
    public void AoPegar()
    {
        Transform maoTrs = GameObject.FindGameObjectWithTag("Hand").transform;

        transform.position = maoTrs.position;
        transform.rotation = Quaternion.Euler(Vector3.zero);
        transform.SetParent(maoTrs);
        _animator.enabled = true;
        _rigidbody.isKinematic = true;
        _collider.enabled = false;
        gameObject.layer = LayerMask.NameToLayer("Item");
    }
    public void AoSoltar()
    {
		transform.SetParent(null);
        transform.position = ItemController.PosicaoSoltar;

		_animator.enabled = false;
		_rigidbody.isKinematic = false;
        _collider.enabled = true;
		gameObject.layer = LayerMask.NameToLayer("Interactable");
	}
}
