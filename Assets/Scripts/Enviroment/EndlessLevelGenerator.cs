using DG.Tweening;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Goost.LD34Peragus
{
    public class EndlessLevelGenerator : MonoBehaviour
    {
#pragma warning disable 0649

        [SerializeField]
        private GameObject _obstacle;

        [SerializeField]
        private GameObject _fireTarget;

        [SerializeField]
        private float _timeBetweenSpawns;

        [SerializeField]
        private int _xStep;

        [SerializeField]
        private GameObject[] _pool1;

        [SerializeField]
        private Transform _parent;

        [SerializeField]
        private int _curX;

        private float _fireTargetpropability;
        private float _obstaclepropability;

        private WaitForSeconds _wait;
        private RunStatus _runStatus;
#pragma warning restore 0649

        private void Awake()
        {
            _wait = new WaitForSeconds(_timeBetweenSpawns);
        }

        private void Start()
        {
            _runStatus = GameObject.FindGameObjectWithTag(Tag.RunStatus).GetComponent<RunStatus>();
            StartCoroutine(SpawnGround());
        }

        private IEnumerator SpawnGround()
        {
            _fireTargetpropability = 0.1f;
            _obstaclepropability = 0.2f;
            DOTween.To(() => _fireTargetpropability, value => _fireTargetpropability = value, 0.8f, 6 * 50)
                .SetEase(Ease.Linear);
            DOTween.To(() => _obstaclepropability, value => _obstaclepropability = value, 0.65f, 6 * 50)
                .SetEase(Ease.Linear);
            while (true)
            {
                if (_runStatus.Running)
                {
                    _curX += _xStep;
                    var index = Random.Range(0, _pool1.Length);
                    var levelchunk =
                        Instantiate(_pool1[index], new Vector3(_curX, -1, 0), Quaternion.identity) as GameObject;
                    levelchunk.transform.SetParent(_parent, false);

                    //NOTE(Goost) Was funny, but unbeatable
                    /*
                    var o = Instantiate(_obstacle,
                                new Vector3(Random.Range((int)2, (int)6), Random.Range((int)1, (int)5)),
                                Quaternion.identity) as GameObject;
                    o.transform.SetParent(levelchunk.transform, false);
                    int howMuch = Random.Range(1, 6);
                    for (int i = 0; i < howMuch;)
                    {
                        var prob = Random.value;
                        if (prob < _fireTargetpropability)
                        {
                            var obstacle = Instantiate(_fireTarget,
                                new Vector3(Random.Range((int)2, (int)6), Random.Range((int)1, (int)5)),
                                Quaternion.identity) as GameObject;
                            print(obstacle.transform.position);
                            obstacle.transform.SetParent(levelchunk.transform, false);
                            i++;
                        }
                    }
                    */
                }
                yield return _wait;
            }
        }
    }
}
