using UnityEngine;

public class Scaler : MonoBehaviour
{
#pragma warning disable 0649

    [SerializeField]
    private float _delimterOne;

    [SerializeField]
    private float _delimterTwo;

    private Camera _cam;
#pragma warning restore 0649

    // Use this for initialization
    private void Start()
    {
        _cam = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        //TODO (goost) To start, in update just for testing
        _cam.orthographicSize = Screen.height / _delimterOne / _delimterTwo;
    }
}
