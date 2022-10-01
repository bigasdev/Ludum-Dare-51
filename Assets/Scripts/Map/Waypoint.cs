using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LudumDare
{
    public class Waypoint : MonoBehaviour
    {
        [SerializeField] Directions direction;
        [SerializeField] Map connectedMap;

        public void Enter(){
            switch(direction){
                case Directions.NORTH:
                    Hero.Instance.transform.position = new Vector2(Hero.Instance.transform.position.x, Hero.Instance.transform.position.y + 6);
                    break;
                case Directions.EAST:
                    Hero.Instance.transform.position = new Vector2(Hero.Instance.transform.position.x + 6, Hero.Instance.transform.position.y);
                    break;
                case Directions.WEST:
                    Hero.Instance.transform.position = new Vector2(Hero.Instance.transform.position.x - 6, Hero.Instance.transform.position.y);
                    break;
                case Directions.SOUTH:
                    Hero.Instance.transform.position = new Vector2(Hero.Instance.transform.position.x, Hero.Instance.transform.position.y - 6);
                    break;
            }
            connectedMap.SetTarget();
        }
    }
    public enum Directions{
        NORTH,
        EAST,
        WEST,
        SOUTH
    }
}
