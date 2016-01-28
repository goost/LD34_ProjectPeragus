using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Goost.LD34Peragus
{
    public class StartUp : MonoBehaviour
    {
#pragma warning disable 0649

        [SerializeField]
        private AudioSource _bg;

        [SerializeField]
        private Text _aboveChar;

        private RunStatus _runStatus;
        private bool _started;

        [SerializeField]
        private GameObject _title;

        private bool _cutscene;

#pragma warning restore 0649

        private void Start()
        {
            _runStatus = GameObject.FindGameObjectWithTag(Tag.RunStatus).GetComponent<RunStatus>();
        }

        private void Update()
        {
            if (_runStatus.Running) return;
            if (_started && !_cutscene)
            {
                _aboveChar.text = "(R)estart?";
                if (Input.GetKeyDown(KeyCode.R))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
            else
            {
                if (_cutscene) return;
                if (!Input.anyKeyDown) return;
                _started = true;
                _cutscene = true;
                StartCoroutine(StartGame());
            }
        }

        private IEnumerator StartGame()
        {
            yield return null; //NOTE(goost) Clear Input.anyKey
            _title.SetActive(false);
            _aboveChar.gameObject.SetActive(true);
            yield return StartCoroutine(ShowText("The Pile of shame...\nIt's coming!"));
            yield return StartCoroutine(WaitForTimeOrInput(1f));
            yield return StartCoroutine(ShowText("Or...Is it?\nIs that the shame?"));
            yield return StartCoroutine(WaitForTimeOrInput(1f));
            yield return StartCoroutine(ShowText("Anyway, gotta run!"));
            yield return StartCoroutine(WaitForTimeOrInput(1f));
            _aboveChar.text = "";
            GetComponentInChildren<Animator>().SetBool("Jogging", true);
            Invoke("RunAnim", 30);
            _bg.Play();
            _runStatus.Running = true;
            _cutscene = false;
        }

        private void RunAnim()
        {
            GetComponentInChildren<Animator>().SetBool("Running", true);
        }

        private IEnumerator WaitForTimeOrInput(float time)
        {
            var endTime = Time.time + time;
            while (Time.time < endTime)
            {
                if (Input.anyKeyDown) break;
                yield return null;
            }
        }

        private IEnumerator ShowText(string what, float wait = 0.05f)
        {
            for (var i = 0; i < what.Length; i++)
            {
                var s = what.Substring(0, i + 1);
                _aboveChar.text = s;
                if (Input.anyKeyDown) break;
                yield return new WaitForSeconds(wait);
            }
            _aboveChar.text = what;
        }
    }
}
