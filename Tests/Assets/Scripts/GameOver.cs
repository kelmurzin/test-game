using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerhealth;
    [SerializeField] private GameObject _panellose;
    [SerializeField] private TimeState _timeState;

    

    public void OnEnable()
    {
        _playerhealth.OnDie += Gameover;
    }

    public void Gameover()
    {
        _panellose.SetActive(true);
        _timeState.Stop();
    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0, UnityEngine.SceneManagement.LoadSceneMode.Single);
        _timeState.Resume();
    }

    public void OnDisable()
    {
        _playerhealth.OnDie -= Gameover;
        
    }
}
