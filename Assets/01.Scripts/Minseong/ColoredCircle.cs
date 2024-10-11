using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredCircle : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0.8f);
    }
}
