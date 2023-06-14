using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderSystem : MonoBehaviour
{

    public float _TempoMinimo;
    public float _TempoMaximo;

    private GameObject _orderPrefab;
    private GameObject _canvasObj;

    void Start()
    {
        _canvasObj = GameObject.FindGameObjectWithTag("Orders Canvas");
        _orderPrefab = Resources.Load("OrderPrefab") as GameObject;
        StartCoroutine(NextOrder());
    }

    void Update()
    {
        
    }

    IEnumerator NextOrder()
    {
        yield return new WaitForSeconds(Random.Range(_TempoMinimo, _TempoMaximo));
        CreateOrder();
    }

    void CreateOrder()
    {
        GameObject newOrder = Instantiate(_orderPrefab, );
    }
}
