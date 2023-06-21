using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarItem : MonoBehaviour, IItem
{

    private Rigidbody _rigidbody;
    private MeshCollider _collider;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<MeshCollider>();
    }
    void Update()
    {

    }

    public void CliquePrincipal()
    {

    }

    public void CliqueSecundario()
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

}
