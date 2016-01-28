using System.Collections;
using UnityEngine;

namespace Goost.LD34Peragus
{
    public class SpawnPrefab : MonoBehaviour
    {
#pragma warning disable 0649

        [SerializeField]
        private GameObject _toSpawn;

#pragma warning restore 0649

        public void Spawn()
        {
            print(transform.position);
            Instantiate(_toSpawn, new Vector3(transform.position.x - 1.5f, transform.position.y), Quaternion.identity);
        }
    }
}
