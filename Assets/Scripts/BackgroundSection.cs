using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WO
{

    public abstract class BackgroundSection : ScriptableObject
    {

        public abstract void Initialize();
        public abstract int GetDefaultTileCount();

        public abstract void StopUsingTile(Transform tile);
        public abstract Transform GetNextTile();

    }
}