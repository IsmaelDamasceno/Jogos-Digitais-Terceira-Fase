using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaTest : MonoBehaviour
{

    private Animator _animator;
    private float _time = 0f;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hammer") && _time < 1f)
        {
            Debug.Log("Hammer aaaaa");
            _time += 0.1f;
            _time = Math.Clamp(_time, 0f, 1f);
            _animator.Play("Flatten", -1, _time);
        }
    }
}
