using Dan.Main;
using Dan.Models;
using TMPro;
using UnityEngine;

namespace Dan.Demo
{
    public class LeaderboardShowcase : MonoBehaviour
    {
        private string _leaderboardPublicKey = "738b16ed30aeae4b7939462a35af960d16a6c8aab59c11984d248d565ce7c938";

        [SerializeField] GameObject ScoreParentObject;

        [SerializeField] GameObject textPrefab;

        private void Start()
        {
            Load();
        }

        private void Load() => LeaderboardCreator.GetLeaderboard(_leaderboardPublicKey, OnLeaderboardLoaded);

        private void OnLeaderboardLoaded(Entry[] entries)
        {

            for (int i = 0; i < entries.Length; i++)
            {
                string score = $"{i + 1}. {entries[i].Username} : {entries[i].Score}";
                Debug.Log(score);
                SpawnScoreObject(score, i);
            }
        }

        private void SpawnScoreObject(string _scoreText, int i)
        {
            // Clone the original TMP text GameObject
            GameObject clonedTextObject = Instantiate(textPrefab, ScoreParentObject.transform.position, ScoreParentObject.transform.rotation);

            // Set the cloned object's parent and adjust its position relative to the previous child
            clonedTextObject.transform.SetParent(ScoreParentObject.transform);
            clonedTextObject.transform.localPosition = new Vector3(0f, -30f * i, 0f); // Position adjustment

            // Access the TMP text component of the cloned object
            TextMeshProUGUI clonedText = clonedTextObject.GetComponent<TextMeshProUGUI>();

            // Modify the properties of the cloned TMP text as needed
            clonedText.text = _scoreText;
        }

    }
}

