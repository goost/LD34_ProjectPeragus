using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace Goost.LD34Peragus
{
    public class Fireball : MonoBehaviour
    {
#pragma warning disable 0649
        public SpawnFireball Spawner { get; set; }

        [SerializeField]
        private GameObject _explosion;

        [SerializeField]
        private float _fireballLength;

        [SerializeField]
        private float _duration;

        [SerializeField]
        private Ease _ease;

#pragma warning restore 0649

        private void Start()
        {
            transform.DOMoveX(transform.position.x - _fireballLength, _duration)
                .SetEase(_ease)
                .OnComplete(() =>
            {
                Spawner.ResetSpawn();
                Destroy(gameObject);
            });
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            //TODO(goost) Or cooldown on SpawnFireball?
            Spawner.ResetSpawn();
            Destroy(gameObject);
            if (!collision.CompareTag(Tag.FireballTarget)) return;
            Destroy(collision.gameObject);
            var cameraOldPOs = Camera.main.transform.position;
            Camera.main.DOShakePosition(0.5f, new Vector3(1, 1, 1)).OnComplete(() =>
            {
                Camera.main.transform.position = cameraOldPOs;
            });
            GameObject.FindGameObjectWithTag(Tag.Counter).GetComponent<TimeMeasure>().CountUp();
            if (_explosion)
            {
                var e = Instantiate(_explosion, collision.transform.position, Quaternion.identity) as GameObject;
                e.transform.SetParent(collision.transform.parent, true);
            }
        }
    }
}
