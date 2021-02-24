using System;
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

        public void SetScore(string name, string points, int time)
        {
            this.name.GetComponent<Text>().text = name;
            this.points.GetComponent<Text>().text = points + " Pts";
            TimeSpan timespan = TimeSpan.FromSeconds(time);
            this.time.GetComponent<Text>().text = timespan.ToString(@"hh\:mm\:ss");
        }
    }
}