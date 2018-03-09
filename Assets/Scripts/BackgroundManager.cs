using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace WO
{
    //Bugfix: This has to be a class in order to set the DefaultTileCount in the list and not a copied struct.
    [System.Serializable]
    public class LevelSection
    {
        public BackgroundSection Section;
        public int TileCount;

        //For OnValidate hack.
        public void SetDefaultTileCount(int value)
        {
            TileCount = value;
        }
    }

    public class BackgroundManager : MonoBehaviour
    {

        //Reference obtained for its transform component for later use.
        public List<LevelSection> BackgroundSections;
        public Transform PlayableArea;
        
        //Active tiles
        private Transform TopActive;
        private Transform BottomActive;



        // Use this for initialization
        void Start()
        {
            Debug.Assert(BackgroundSections != null, "Missing backgrounds! [" + this + "]");
        }

        // Update is called once per frame
        void Update()
        {

        }


        private void OnValidate()
        {
            //Really hacky code
            if (BackgroundSections != null)
            {
                foreach (var section in BackgroundSections)
                {
                    if (section.Section != null && section.TileCount == 0)
                    {
                        section.SetDefaultTileCount(section.Section.GetDefaultTileCount());
                    }
                }
            }
        }
    }
}