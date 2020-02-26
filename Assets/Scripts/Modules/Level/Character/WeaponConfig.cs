﻿using UnityEngine;

namespace Modules.Level.Character
{
    [CreateAssetMenu]
    public class WeaponConfig : ScriptableObject
    {
        [SerializeField]
        private string _title;
        public string Title => _title;

        [SerializeField]
        private float _reloadingTimeSeconds;
        public float ReloadingTimeSeconds => _reloadingTimeSeconds;

        [SerializeField]
        private float _damage;
        public float Damage => _damage;

        [SerializeField]
        private float _range;
        public float Range => _range;
    }
}
