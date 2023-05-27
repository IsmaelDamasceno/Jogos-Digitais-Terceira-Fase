using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HammerItem : MonoBehaviour, IItem
{

    [SerializeField] private bool _pronto;
    private Animator _animator;

    public void LeftClick()
    {
        if (_pronto)
        {
            _animator.SetBool("Hitting", true);
            _pronto = false;
        }
    }

    public void RightClick()
    {

    }

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void FinalizarGolpe()
    {
        _pronto = true;
    }
}
