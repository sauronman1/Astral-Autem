using System;
using UnityEngine;
using UnityEngine.UI;

namespace FG {
	public class SliderBar : MonoBehaviour {
		
		[SerializeField] private float                 healthLerpSpeed =0;
		[SerializeField] private Health                health;
		private                  MaterialPropertyBlock _propBlock;
		private                  Renderer              _renderer;
		
		private void Start()
		{
			_renderer = GetComponent<Renderer>();
			_propBlock = new MaterialPropertyBlock();
			_propBlock.SetFloat("_HealthAmount", 1);
			_renderer.SetPropertyBlock(_propBlock);
		}

		private void Update()
		{
			DamageTransition();
		}
		
		private void DamageTransition()
		{
			_renderer.GetPropertyBlock(_propBlock);
			float xScale = Mathf.Lerp(_propBlock.GetFloat("_HealthAmount"), health.currentHealthInMPropertyValue, healthLerpSpeed * Time.deltaTime);
			_propBlock.SetFloat("_HealthAmount", xScale);
			_renderer.SetPropertyBlock(_propBlock);
		}
	}
}
