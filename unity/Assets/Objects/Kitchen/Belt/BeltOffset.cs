using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class BeltOffset : MonoBehaviour
{

    public static float s_Velocidade = 0.1f;
    public static BeltOffset s_instancia;
    private static Material s_materialBelt;
    private static float s_texturaAltura;
    private static Vector2 s_offset;


    private void Awake()
    {
        if (s_instancia == null)
        {
            s_instancia = this;
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
        s_offset.y -= (Time.deltaTime * s_Velocidade) % s_texturaAltura;
        s_materialBelt.SetTextureOffset("_MainTex", s_offset);
    }

    public static void Iniciar()
    {
        s_materialBelt = s_instancia.GetComponent<Renderer>().material;
        s_texturaAltura = s_materialBelt.GetTexture("_MainTex").height;
    }

}
