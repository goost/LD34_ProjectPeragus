using System.Collections;
using UnityEngine;

namespace Goost.LD34Peragus
{
    public class ExposeDestroy : MonoBehaviour
    {
#pragma warning disable 0649

#pragma warning restore 0649

        public void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}
