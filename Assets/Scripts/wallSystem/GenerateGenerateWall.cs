﻿using UnityEngine;
using UnityEngine.UI;
using DS = data.DataSingleton;
using E = main.Loader;
//This script is the Generate (GenerateWall) script
//This is essentially the god class, the backbone of the project.
namespace wallSystem
{
    public class GenerateGenerateWall : MonoBehaviour
    {
        //-------------------------- Fields -------------------------------------
        public GameObject Create; //This is the prefab of the GenerateWall object.
        public GameObject GenerateEnclosureFromFile;
        public Camera Cam;        //This is the main camera of the player.
        public Text Timer;        //This exists as the timer text.
        public GameObject Player;

        public int currBlockId; // The id of the current block being tested.
        public int currTrialId; // The id of the current trial being tested.

        //current generate wall object that exists. This is intrinsically different from 
        //the Create object as that is a prefab while this is the instance.
        private GameObject _currCreate;

        //This is the current running timestamp that is outputted to the outputfile.
        private readonly float _timestamp;

        // Use this for initialization
        private void Start()
        {
            Create.transform.position = Vector3.zero;
            _currCreate = Instantiate(E.Get().CurrTrial.enclosure.Sides == 0 ? GenerateEnclosureFromFile : Create);
        }

        private void Update()
        {

            currBlockId = E.Get().CurrTrial.BlockID;
            currTrialId = E.Get().CurrTrial.TrialID;

            if (DS.GetData().Blocks[currBlockId].ShowNumSuccessfulTrials)
            {
                var goalText = GameObject.Find("Goal").GetComponent<Text>();
                goalText.color = Color.green;
                goalText.text = "Number of successes: " + E.Get().CurrTrial.TrialProgress.NumSuccess + "/3";
            }
            if (DS.GetData().Trials[currTrialId].ShowCollectedPerTrial)
            {
                if (DS.GetData().MorrisMazeThreshold != 0)
                {
                    if (E.Get().CurrTrial.NumCollected <= DS.GetData().MorrisMazeThreshold)
                    {
                        var CollectionText = GameObject.Find("CountDown").GetComponent<Text>();
                        CollectionText.text = "Money Collected: $" +  E.Get().CurrTrial.NumCollected*0.01f + "/" + DS.GetData().MorrisMazeThreshold*0.01f;
                        CollectionText.color = Color.red;
                        var goalText = GameObject.Find("Goal").GetComponent<Text>();
                        goalText.color = Color.green;
                    }
                    else
                    {
                        var CollectionText = GameObject.Find("CountDown").GetComponent<Text>();
                        CollectionText.text = "Round Bonus Complete! MEGABONUS POINTS: " + (E.Get().CurrTrial.NumCollected - DS.GetData().MorrisMazeThreshold);
                        CollectionText.color = Color.green;
                        var goalText = GameObject.Find("Goal").GetComponent<Text>();
                        goalText.color = Color.green;
                    }
                    //Timer.text = "Trial Bonus Complete! Keep Collecting for Mega BONUS!: " + E.Get().CurrTrial.NumCollected;
                }
                else
                {
                    Timer.text = "Money Collected: $" + E.Get().CurrTrial.NumCollected*0.01f;
                    Timer.color = Color.green;
                    var goalText = GameObject.Find("Goal").GetComponent<Text>();
                    goalText.color = Color.green;
                }

            }
            else if (DS.GetData().Trials[currTrialId].ShowCollectedPerBlock)
            {
                Timer.text = "Money Collected: $" + E.Get().CurrTrial.TrialProgress.NumCollectedPerBlock[currBlockId]*0.01f;
            }
            

        }
    }
}
