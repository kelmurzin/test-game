using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFX : MonoBehaviour
{
    public static ParticleFX Instance;

    [SerializeField] private ParticleSystem ExplosionFX;
    [SerializeField] private ParticleSystem EnemyExplosionFX;

    ParticleSystem.MainModule ExplosionFXMainModule;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ExplosionFXMainModule = ExplosionFX.main;
    }
    public void PlayExplosionFX(Vector3 position)
    {
        
        ExplosionFX.transform.position = position;
        ExplosionFX.Play();
    }
    public void EnemyRangeExplosionFX(Vector3 position)
    {

        EnemyExplosionFX.transform.position = position;
        EnemyExplosionFX.Play();
    }

}
