using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRespawn : MonoBehaviour
{

    public static Vector3 s_pontoRespawn = new Vector3(1.96700001f, 0.771000028f, -0.853999972f);

    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.y <= -2.4f)
        {
            transform.position = s_pontoRespawn;
		}
    }
}
