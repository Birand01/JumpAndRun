
using System.Collections.Generic;
using UnityEngine;

public enum ParticleType
{
   CrashParticle,
   DirtParticle
}

public class ParticleManager : MonoBehaviour
{
    [SerializeField] private List<ParticleSystem> particles = new List<ParticleSystem>();


    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            particles.Add(transform.GetChild(i).gameObject.GetComponent<ParticleSystem>());
        }
    }


    //private void OnEnable()
    //{
    //    GroundInteraction.OnDirtParticle += PlayParticle;
    //    ObstacleInteraction.OnCrashParticle += PlayParticle;      
    //}

    //private void OnDisable()
    //{
    //    ObstacleInteraction.OnCrashParticle -= PlayParticle;
    //    GroundInteraction.OnDirtParticle -= PlayParticle;

    //}
    private void PlayParticle(ParticleType typeOfParticle, Vector3 _position,bool state)
    {

        for (int i = 0; i < particles.Count; i++)
        {
            if (particles[i].GetComponent<ParticleConfig>().particleSO.particleType == typeOfParticle && state)
            {
                //Debug.Log(particles[i].name);
                particles[i].transform.position = _position;
                particles[i].Play();
                particles[i].Clear();
                return;
            }
            else
            {
                particles[i].Stop();
                particles[i].Clear();
            }

        }

    }

}
