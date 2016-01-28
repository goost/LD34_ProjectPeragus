using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace Goost.LD34Peragus
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class AutoMove : MonoBehaviour
    {
#pragma warning disable 0649

        [SerializeField]
        private float _speed;

        private Rigidbody2D _rb;

        [SerializeField]
        private float _initialForce;

        private RunStatus _runStatus;

#pragma warning restore 0649

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            //_rb.AddForce(Vector2.right * _initialForce);
            _runStatus = GameObject.FindGameObjectWithTag(Tag.RunStatus).GetComponent<RunStatus>();
            DOTween.To(() => _speed, value => _speed = value, _speed * 10, 4 * 60).SetEase(Ease.InQuad);
        }

        private void Update()
        {
            if (!_runStatus.Running) return;
            _rb.MovePosition(_rb.position + Vector2.right * Time.deltaTime * _speed);
            //Vector3.MoveTowards(transform.position, transform.position + Vector3.right * Time.deltaTime * _speed, 0.2f);
        }
    }
}
