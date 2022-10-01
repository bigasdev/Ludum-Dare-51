using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

namespace LudumDare
{
    public class PostProcess : MonoBehaviour
    {
        private static PostProcess instance;
        public static PostProcess Instance{
            get{
                if(instance == null)instance = FindObjectOfType<PostProcess>();
                return instance;
            }
        }
        [SerializeField] PostProcessVolume volume;
        public Bloom bloom;
        public DepthOfField depthOfField;
        public Vignette vignette;
        public LensDistortion distortion;

        private void Start() {
            volume.profile.TryGetSettings<Bloom>(out bloom);
            volume.profile.TryGetSettings<DepthOfField>(out depthOfField);
            volume.profile.TryGetSettings<Vignette>(out vignette);
            volume.profile.TryGetSettings<LensDistortion>(out distortion);
        }
    }
}
