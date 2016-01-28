using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace Goost.LD34Peragus
{
    public class SpawnFireball : MonoBehaviour
    {
#pragma warning disable 0649

        [SerializeField]
        private GameObject _fireball;

        private RunStatus _runStatus;
        private bool _spawn;
#pragma warning restore 0649

        private void Start()
        {
            _runStatus = GameObject.FindGameObjectWithTag(Tag.RunStatus).GetComponent<RunStatus>();
        }

        private void Update()
        {
            if (!_runStatus.Running) return;
            if (!Input.GetKeyDown(KeyCode.S)) return;
            if (_spawn) return;
            _spawn = true;
            (Instantiate(_fireball, new Vector3(transform.position.x - 0.7f, transform.position.y), Quaternion.identity) as GameObject)
                .GetComponent<Fireball>().Spawner = this;
        }

        public void ResetSpawn()
        {
            _spawn = false;
        }
    }
}
