using UnityEngine;

namespace FG {
	public class Scaler : MonoBehaviour
	{
		[SerializeField] private float _speed;
		private Renderer _renderer;
		private float _width;
		private float _height;
		private Transform _transform;
		
		private void Start()
		{
			_transform = transform;
			_renderer = GetComponent<Renderer>();
			if (_renderer == null) return;
			_transform.localScale = new Vector3(Screen.width , Screen.height, _transform.localScale.z);
		}

		private void Update()
		{
			_renderer.material.mainTextureOffset += new Vector2(0, _speed * Time.deltaTime);
		}
	}
}
