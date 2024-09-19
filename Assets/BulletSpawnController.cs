using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class BulletSpawnController : MonoBehaviour
{
    public InputActions _input;
    public float LookDeg;
    public float Aim;
    public float TurnDeg;
    public float Deg;
    public float x;
    public float y;

    private void Start()
    {
        _input = gameObject.GetComponentInParent<InputActions>();
    }

    // Update is called once per frame
    void Update()
    {
        x = _input.Look.x;
        y = _input.Look.y;
        LookDeg = -1 * Mathf.Rad2Deg * Mathf.Atan2(_input.Look.x, _input.Look.y);
        if (LookDeg == 0) {Aim = -90;} else {Aim = LookDeg;}
        Deg = transform.rotation.eulerAngles.z;
        TurnDeg = Deg - Aim;
        transform.RotateAround(transform.parent.transform.position, Vector3.back, TurnDeg);
    }
}
