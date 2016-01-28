using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Goost.LD34Peragus
{
    public class TimeMeasure : MonoBehaviour
    {
#pragma warning disable 0649

        [SerializeField]
        private Text _text;

        private float _init;
        private RunStatus _runStatus;
        private int _counter;
#pragma warning restore 0649

        private void Start()
        {
            _runStatus = GameObject.FindGameObjectWithTag(Tag.RunStatus).GetComponent<RunStatus>();
        }

        private void Update()
        {
            if (!_runStatus.Running)
            {
                _init = Time.time;
            }
            else
            {
                float time = (int)((Time.time - _init) / 60 * 100);
                time = time / 100f;
                _text.text = time + " min survived";
                if (_counter > 0)
                {
                    _text.text = _text.text + "\n" + _counter + " Walls destroyed";
                }
            }
        }

        public void CountUp()
        {
            _counter++;
        }
    }
}
