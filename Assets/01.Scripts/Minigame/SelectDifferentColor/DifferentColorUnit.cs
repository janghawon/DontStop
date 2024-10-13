using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifferentColorUnit : MonoBehaviour
{
    private void OnMouseDown()
    {
        CallbackManager.Instance.Callback("NextGame");
    }
}
