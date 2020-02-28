﻿using UnityEngine;
using System;

namespace Modules.Level
{
    public class GameRulesManager
    {
        // interface
        public event Action OnVictory;
        public event Action OnDefeat;

        // dependencies
        private int _enemiesCount;

        // victory conditions
        private bool _allEnemiesKilled;
        private bool _escapeZoneEntered;
        // defeat condition
        private bool _playerKilled;

        public GameRulesManager(PlayerManager playerManager, EnemiesManager enemiesManager, EscapeZoneView escapeZone)
        {
            _enemiesCount = enemiesManager.Enemies.Count;
            _allEnemiesKilled = false;
            _escapeZoneEntered = false;
            _playerKilled = false;

            enemiesManager.OnEnemyKilled += DecreaseEnemiesCount;
            playerManager.OnPlayerKilled += OnPlayerKilled;
            escapeZone.OnZoneEntered += OnEscapeZoneEntered;
            escapeZone.OnZoneLeft += OnEscapeZoneLeft;
        }

        private void DecreaseEnemiesCount()
        {
            _enemiesCount--;
            CheckEnemiesCondition();
        }

        private void CheckEnemiesCondition()
        {
            if (_enemiesCount == 0)
            {
                _allEnemiesKilled = true;
                CheckVictoryConditions();
            }
        }

        private void OnPlayerKilled()
        {
            _playerKilled = true;
            CheckDefeatConditions();
        }

        private void OnEscapeZoneEntered(Collider other)
        {
            Character.CharacterView character = other.transform.parent.GetComponent<Character.CharacterView>();

            if (character != null && character.tag == "Player")
            {
                _escapeZoneEntered = true;
                CheckVictoryConditions();
            }
        }

        private void OnEscapeZoneLeft(Collider other)
        {
            Character.CharacterView character = other.transform.parent.GetComponent<Character.CharacterView>();

            if (character != null && character.tag == "Player")
            {
                _escapeZoneEntered = false;
            }
        }

        private void CheckVictoryConditions()
        {
            if (_allEnemiesKilled && _escapeZoneEntered)
            {
                OnVictory?.Invoke();
            }
        }

        private void CheckDefeatConditions()
        {
            if (_playerKilled)
            {
                OnDefeat?.Invoke();
            }
        }
    }
}
