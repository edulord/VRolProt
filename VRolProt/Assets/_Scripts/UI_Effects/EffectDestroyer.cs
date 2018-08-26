using UnityEngine;
using System.Collections;

public class EffectDestroyer : MonoBehaviour 
{
	public ParticleSystem particle;
	
	public void Start()
	{
		if (particle)
			particle.Play();
	}

	public void Update()
	{
		if (particle)
		{
			if (!particle.IsAlive())
			{
                Destroy(gameObject);
			}
		}
	}
}
