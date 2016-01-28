using System.Collections;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class Stalker : MonoBehaviour
{
#pragma warning disable 0649

    [SerializeField]
    private Transform _target;

    private Camera _cam;
#pragma warning restore 0649

    private void Awake()
    {
        _cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    private void Update()
    {
        var goal = _target.position;
        goal.x += 0.1f;
        goal.z = -10;
        transform.position = Vector3.Lerp(transform.position, goal, 0.09f);
    }

    private void ChangeTarget(Transform newTarget)
    {
        _target = newTarget;
    }
}
