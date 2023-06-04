using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class BeltOffset : MonoBehaviour
{

    public static float _Velocidade = 0.1f;
    public static BeltOffset _instancia;
    private static Material _materialBelt;
    private static float _texturaAltura;
    private static Vector2 _offset;


    private void Awake()
    {
        if (_instancia == null)
        {
            _instancia = this;
            Iniciar();
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        
    }

    private void Update()
    {
        _offset.y -= (Time.deltaTime * _Velocidade) % _texturaAltura;
        _materialBelt.SetTextureOffset("_MainTex", _offset);
    }

    public static void Iniciar()
    {
        _materialBelt = _instancia.GetComponent<Renderer>().material;
        _texturaAltura = _materialBelt.GetTexture("_MainTex").height;
    }

}
