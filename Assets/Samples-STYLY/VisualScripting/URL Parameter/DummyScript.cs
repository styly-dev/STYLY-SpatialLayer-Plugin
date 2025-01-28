using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Styly.VisionOs.Samples.URLSchemeParameter
{
    public class DummyScript : MonoBehaviour
    {
        [SerializeField] private string url = "styly-vos://layer/dummy-content-id?type=Unbounded&param1=123&param2=abcd";
        
        // Start is called before the first frame update
        void Awake()
        {
            StylySystemInfoManager.SetInfo(StylySystemInfo.URL_KEY, url);
        }
    }

}
