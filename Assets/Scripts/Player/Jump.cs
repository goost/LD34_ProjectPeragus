using DG.Tweening;
using DG.Tweening.Core;
using System.Collections;
using UnityEngine;

namespace Goost.LD34Peragus
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Jump : MonoBehaviour
    {
#pragma warning disable 0649
        private readonly int _inAirHash = Animator.StringToHash("InAir");
        private Animator _animator;

        [SerializeField]
        private Ease _easeUp;

        [SerializeField]
        private Ease _easeDown;

        [SerializeField]
        private float _jumpHeight;

        [SerializeField]
        private float _duration;

        private Rigidbody2D _rb;
        private bool _inAir;
        private RunStatus _runStatus;

#pragma warning restore 0649

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            _rb = GetComponent<Rigidbody2D>();
            _runStatus = GameObject.FindGameObjectWithTag(Tag.RunStatus).GetComponent<RunStatus>();
        }

        private void Update()
        {
            if (!_runStatus.Running) return;
            var hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.7f), Vector2.down, 1, Layer.GroundMask);
            _animator.SetBool(_inAirHash, _inAir);
            if (hit.collider && hit.fraction == 0 && !_inAir)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _inAir = true;
                    _animator.SetBool(_inAirHash, _inAir);
                    DOTween.To(() => transform.position, value => transform.position = value,
                        Vector3.up * _jumpHeight, _duration)
                        .SetEase(_easeUp)
                        .OnComplete(() =>
                        {
                            DOTween.To(() => transform.position, value => transform.position = value,
                                Vector3.zero, _duration)
                                .SetEase(_easeDown)
                                .OnComplete(() => _inAir = false);
                        });
                }
            }
        }
    }
}
