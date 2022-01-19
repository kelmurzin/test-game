using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private GameObject _panelpause;
    [SerializeField] private TimeState _timeState;

    public void Pause()
    {
        _timeState.Stop();
        _panelpause.SetActive(true);
    }

    public void Resume()
    {
        _timeState.Resume();
        _panelpause.SetActive(false);
    }

}
