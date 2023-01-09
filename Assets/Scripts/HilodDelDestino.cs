using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HilodDelDestino : MonoBehaviour
{
    LineRenderer _HiloRend;
    EdgeCollider2D _Col;

    public List<Vector2> _LinePoints = new List<Vector2>();

    // Start is called before the first frame update
    void Start()
    {
        _HiloRend = GetComponent<LineRenderer>();
        _Col = GetComponent<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _LinePoints[0] = _HiloRend.GetPosition(0);
        _LinePoints[1] = _HiloRend.GetPosition(1);
        _Col.SetPoints(_LinePoints);
    }
}
