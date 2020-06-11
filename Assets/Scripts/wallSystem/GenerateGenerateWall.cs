using UnityEngine;
using UnityEngine.UI;
using DS = data.DataSingleton;
using E = main.Loader;
using trial;
using System;
using data;
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
                var successText = GameObject.Find("TrialSuccess").GetComponent<Text>();
                successText.text = "Rounds Complete: " + E.Get().CurrTrial.TrialProgress.NumSuccess + "/4";
            }
            if (DS.GetData().Trials[currTrialId].ShowCollectedPerTrial)
            {
                if (DS.GetData().MorrisMazeThreshold != 0)
                {
                    if (E.Get().CurrTrial.NumCollected < DS.GetData().MorrisMazeThreshold)
                    {
                        var CollectionText = GameObject.Find("TrialTotal").GetComponent<Text>();
                        CollectionText.text = "Money Collected: " +  Math.Round(E.Get().CurrTrial.NumCollected*0.5f, 2) + "¢";
                        CollectionText.color = Color.red;
                    }
                    else if (E.Get().CurrTrial.NumCollected >= DS.GetData().MorrisMazeThreshold & E.Get().CurrTrial.enclosure.WallColor != "ffffff00")
                    {
                        var CollectionText = GameObject.Find("TrialTotal").GetComponent<Text>();
                        CollectionText.text = "Bonus Collected: " + Math.Round(E.Get().CurrTrial.NumCollected * 0.5f, 2) + "¢";
                        CollectionText.color = Color.green;
                        var headerText = GameObject.Find("Header").GetComponent<Text>();
                        headerText.text = "BONUS UNLOCKED!!";
                        headerText.color = Color.green;
                    }
                    else if (E.Get().CurrTrial.NumCollected >= DS.GetData().MorrisMazeThreshold)
                    {
                        var CollectionText = GameObject.Find("TrialTotal").GetComponent<Text>();
                        CollectionText.color = Color.green;
                        CollectionText.text = "Money Collected: " + Math.Round(E.Get().CurrTrial.NumCollected * 0.5f, 2) + "¢";
                        var headerText = GameObject.Find("Header").GetComponent<Text>();
                        headerText.color = Color.green;
                        var SuccessText = GameObject.Find("TrialSuccess").GetComponent<Text>();
                        SuccessText.color = Color.green;
                    }
                    //Timer.text = "Trial Bonus Complete! Keep Collecting for Mega BONUS!: " + E.Get().CurrTrial.NumCollected;
                }
                else
                {
                    var CollectionText = GameObject.Find("TrialTotal").GetComponent<Text>();
                    CollectionText.text = "Money Collected: $" + E.Get().CurrTrial.NumCollected * 0.01f;
                    CollectionText.color = Color.green;
                    var headerText = GameObject.Find("Header").GetComponent<Text>();
                    headerText.color = Color.green;
                }
            }
            else if (DS.GetData().Trials[currTrialId].ShowCollectedPerBlock)
            {
                    Timer.text = "Great Job! \nYou Earned a Bonus Payment of $" + Math.Round(E.Get().CurrTrial.TrialProgress.NumCollectedPerBlock[currBlockId] * 0.005 + 0.5f, 2) ;
            }

            if(E.Get().CurrTrial.NumCollected >= DS.GetData().MorrisMazeThreshold)
            {
                var SuccessText = GameObject.Find("TrialSuccess").GetComponent<Text>();
                SuccessText.color = Color.green;
            }

        }
    }
}
