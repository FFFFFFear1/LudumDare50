using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            Destroy(gameObject);
        }
    }
}
