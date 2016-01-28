using System.Collections;
using UnityEngine;

namespace Goost.LD34Peragus
{
    public class RunStatus : MonoBehaviour
    {
        private bool _running;
        //TODO (goost) Looks like I do not need something like this....
        public event OnStatusChangeHandler OnStatusChange;
        public delegate void OnStatusChangeHandler(bool newStatus);

        public bool Running
        {
            get { return _running; }
            set
            {
                _running = value;
                if (OnStatusChange != null)
                {
                    OnStatusChange(value);
                }
            }
        }
    }
}
