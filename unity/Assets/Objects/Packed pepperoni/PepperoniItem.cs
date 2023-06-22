using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PepperoniItem : MonoBehaviour, IItem
{
    private Rigidbody _rigidbody;
    private BoxCollider _collider;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<BoxCollider>();
    }

    void Update()
    {

    }

    public void AoPegar()
    {
        Transform maoTrs = GameObject.FindGameObjectWithTag("Hand").transform;

        transform.position = maoTrs.position;
        transform.rotation = Quaternion.Euler(Vector3.left * 90f);
        transform.SetParent(maoTrs);
        _rigidbody.isKinematic = true;
        _collider.enabled = false;
        gameObject.layer = LayerMask.NameToLayer("Item");
    }

    public void AoSoltar()
    {
        transform.SetParent(null);
        transform.position = ItemController.PosicaoSoltar;

        _rigidbody.isKinematic = false;
        _collider.enabled = true;
        gameObject.layer = LayerMask.NameToLayer("Interactable");
    }

    public void CliquePrincipal()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hitInfo, 2, 1 << 6))
        {
            PizzaMount pizzaMount = hitInfo.collider.GetComponent<PizzaMount>();
            if (pizzaMount != null)
            {
                pizzaMount.MountIngridient(3);
            }
        }
    }

    public void CliqueSecundario()
    {

    }
}
