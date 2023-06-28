using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRespawn : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.y <= -2.4f)
        {
            transform.position = new Vector3(1.96700001f, 0.771000028f, -0.853999972f);
		}
    }
}
