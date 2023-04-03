using System.Collections;
using UnityEngine;
// TODO: Document

namespace Assets.Scripts.Camera
{
    public class CameraStartUp : MonoBehaviour
    {
        public GameObject foundObj;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Finder();
            if (foundObj != null ) 
            {
                GetComponent<FollowPlayer>().target = foundObj.transform;
                Destroy(this);
            }

        }

        public void Finder()
        {
            if (GameObject.FindWithTag("Player"))
            {
                foundObj = GameObject.FindWithTag("Player");
            }
        }
    }
}