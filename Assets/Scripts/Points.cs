using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    private static Points _instance;

    public static Points Instance{get { return _instance; }}

    public int point { get; set; }

    public void SetDefault(Points p)
    {
        _instance = p;
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }

        else
        {
            _instance = this;
        }
    }
}
