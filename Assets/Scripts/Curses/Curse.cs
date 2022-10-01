using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

namespace LudumDare
{
    public class Curse : MonoBehaviour
    {
        [SerializeField] List<CurseProfile> curses = new List<CurseProfile>();
        private void Start() {
            CurseController.Instance.curses = curses;

            GetCurse("Freeze").evnt.AddListener(()=>{
                Hero.Instance.moveSpeed = 0;
            });
            
            Hero.Instance.OnCleanse.AddListener(()=>{Hero.Instance.moveSpeed = 4;});

            GetCurse("Slow").evnt.AddListener(()=>{
                Hero.Instance.moveSpeed = 2;
            });

            GetCurse("No weapon").evnt.AddListener(()=>{
                Hero.Instance.canAttack = false;
            });

            Hero.Instance.OnCleanse.AddListener(()=>{Hero.Instance.canAttack = true;});

            GetCurse("Turbo enemies").evnt.AddListener(()=>{

            });

            GetCurse("Blurry").evnt.AddListener(()=>{
                PostProcess.Instance.depthOfField.active = true;
            }); 
            GetCurse("Darkness").evnt.AddListener(()=>{
                PostProcess.Instance.vignette.active = true;
            });
            GetCurse("Weird lens").evnt.AddListener(()=>{
                PostProcess.Instance.distortion.active = true;
            });

            Hero.Instance.OnCleanse.AddListener(()=>{
                PostProcess.Instance.depthOfField.active = false;
                PostProcess.Instance.vignette.active = false;
                PostProcess.Instance.distortion.active = false;
            });
        }
        public CurseProfile GetCurse(string name){
            return curses.Where(x=>x.name == name).FirstOrDefault();
        }
    }
    [System.Serializable]
    public class CurseProfile{
       public string name;
       public string description;
       public Sprite icon;
       public UnityEvent evnt = new UnityEvent();

        public CurseProfile(string name, string description, Sprite icon)
        {
            this.name = name;
            this.description = description;
            this.icon = icon;
        }
    }
}
