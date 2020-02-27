using UnityEngine;
using Modules.Level.Character;

namespace Modules.Level
{
    public static class CharacterSpawner
    {
        public static Character.CharacterController Spawn(CharacterParams characterParams, Transform arenaTransform, Vector3 characterSpawnPoint)
        {
            CharacterView characterView = Object.Instantiate(characterParams.CharacterViewPrefab, arenaTransform);
            characterView.transform.localPosition = characterSpawnPoint;
            Character.CharacterController characterController = new Character.CharacterController(characterParams, characterView);

            return characterController;
        }
    }
}
