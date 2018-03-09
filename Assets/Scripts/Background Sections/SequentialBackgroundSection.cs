using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WO
{
    [CreateAssetMenu(fileName = "New Seq BG Section", menuName = "Background Section/Sequential")]
    public class SequentialBackgroundSection : BackgroundSection
    {

        public List<Transform> PrefabTileList;
        private List<Transform> SceneTileList;
        private int index = 0;

        public override void Initialize()
        {
            index = 0;
            Debug.Assert(PrefabTileList.Count > 0, "TileList is Empty! [" + this + "]");

            if(SceneTileList == null)
            {
                //Allocate based on number of prefabs
                SceneTileList = new List<Transform>(PrefabTileList.Count);

                foreach(Transform tr in PrefabTileList)
                {
                    //Instantiate. Disable. Add.
                    Transform temp = Instantiate(tr);
                    temp.gameObject.SetActive(false);
                    SceneTileList.Add(temp);
                }
            }
        }
        public override int GetDefaultTileCount()
        {
            return PrefabTileList.Count;
        }

        public override void StopUsingTile(Transform tile)
        {
            tile.gameObject.SetActive(false);
        }
        public override Transform GetNextTile()
        {
            Transform nextTile = SceneTileList[index];
            nextTile.gameObject.SetActive(true);
            index++;
            index = ClampIndex(index, 0, SceneTileList.Count);
            return nextTile;
        }

        private int ClampIndex(int index, int min, int max)
        {
            if (index >= max)
            {
                index = min;
            }
            return index;
        }
    }

}