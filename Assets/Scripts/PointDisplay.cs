using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class PointDisplay : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _title;

    void Start()
    {
        _title.SetText("Score: ");
    }
    void Update()
    {
        _title.SetText("Score: " + Points.Instance.point.ToString());
    }
}
