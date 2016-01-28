using System.Collections;
using UnityEngine;

namespace Goost.LD34Peragus
{
    public class DestroyOnTrigger : MonoBehaviour
    {
#pragma warning disable 0649

#pragma warning restore 0649

        public void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(collision.gameObject);
        }
    }
}
