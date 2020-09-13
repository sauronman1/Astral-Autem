using UnityEngine;

namespace FG {
	public class Scaler : MonoBehaviour
	{
		private SpriteRenderer _spriteRend;
		private float _width;
		private float _height;
		private Transform _transform;
		
		private void Start()
		{
			_transform = transform;
			_spriteRend = GetComponent<SpriteRenderer>();
			if (_spriteRend == null) return;
			_width = _spriteRend.sprite.bounds.size.x;
			_height = _spriteRend.sprite.bounds.size.y;
			_transform.localScale = new Vector2(Screen.width / _width, Screen.height / _height);
		}
	}
}
