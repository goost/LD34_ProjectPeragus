using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace Goost.LD34Peragus
{
    public class SplashOnTrigger : MonoBehaviour
    {
#pragma warning disable 0649

        [SerializeField]
        private AudioSource _bg;

        [SerializeField]
        private GameObject _splatter;

        [SerializeField]
        private GameObject _stain;

        [SerializeField]
        private AudioClip _endMusic;

#pragma warning restore 0649

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag(Tag.Obstacle) && !collision.CompareTag(Tag.FireballTarget)) return;
            GetComponentInChildren<Animator>().SetTrigger("Hit");
            GetComponent<AudioSource>().Play();
            Instantiate(_splatter, new Vector3(transform.position.x + 0.5f, transform.position.y + 0.5f),
                Quaternion.identity);
            Instantiate(_stain, new Vector3(transform.position.x - 1f, transform.position.y), Quaternion.identity);
            Camera.main.DOShakePosition(0.5f, new Vector3(2, 2, 2), 10);
            _bg.Stop();
            _bg.clip = _endMusic;
            _bg.Play();
            GameObject.FindGameObjectWithTag(Tag.RunStatus).GetComponent<RunStatus>().Running = false;
        }
    }
}
