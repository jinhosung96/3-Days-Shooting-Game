using UnityEngine;

// ReSharper disable once CheckNamespace
namespace QFX.IFX
{
	public class IFX_Minigun : MonoBehaviour
	{
		public ParticleSystem ProjectilePs;
		public ParticleSystem MuzzleFlashPs;
		public ParticleSystem SleevesPs;

		public float FireRate;

		public AudioClip AudioClip;
		public AudioSource AudioSource;

		private bool _isButtonHold;
		private float _time;

		private void Update()
		{
			_isButtonHold = true;

			GetComponent<Animator>().SetBool("IsShoot", _isButtonHold);

			_time += Time.deltaTime;

			if (!_isButtonHold)
				return;

			if (_time < FireRate)
				return;

			ProjectilePs.Emit(1);
			MuzzleFlashPs.Play(true);
			SleevesPs.Emit(1);

			if (AudioSource != null && AudioClip != null)
				AudioSource.PlayOneShot(AudioClip, 0.5f);

			_time = 0;
		}
	}
}
