using System.Collections.Generic;
using UnityEngine;

namespace FG {
	public class WeaponsManager : MonoBehaviour
	{
		[SerializeField] private GameObject[]     weapons;
		public static            List<GameObject> WeaponsList = new List<GameObject>();

		private void Awake()
		{
			foreach (GameObject weapon in weapons)
			{
				WeaponsList.Add(weapon);
			}
		}
	}
}
