using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField]
    private Camera _cam;

    // Use this for initialization
    private void Start()
    {
        _cam = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        //TODO (goost) To start, in update just for testing
        _cam.orthographicSize = Screen.height / 125f / 6f;
    }
}