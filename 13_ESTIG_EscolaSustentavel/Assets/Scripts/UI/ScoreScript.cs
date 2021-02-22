using Database.Model;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ScoreScript : MonoBehaviour
    {
        public GameObject name;
        public GameObject points;
        public GameObject time;

        public void SetScore(string name, string points, string time)
        {
            this.name.GetComponent<Text>().text = name;
            this.points.GetComponent<Text>().text = points;
            this.time.GetComponent<Text>().text = time;
        }
    }
}