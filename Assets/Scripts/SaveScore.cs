using Dan.Main;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Dan.Demo
{
    public class SaveScore: MonoBehaviour
    {
        private string _leaderboardPublicKey = "738b16ed30aeae4b7939462a35af960d16a6c8aab59c11984d248d565ce7c938";

        private TMP_InputField _playerUsernameInput;
        [SerializeField] GameObject PlayerNameInput;
        [SerializeField] GameObject SubmitButton;
        [SerializeField] GameObject SuccessMessage;
        [SerializeField] GameObject MainMenuButton;

        private int _playerScore;

        private void Awake()
        {
            _playerUsernameInput = PlayerNameInput.GetComponent<TMP_InputField>();
        }

        public void SetNameAndScore(int _score)
        {
            _playerScore = _score;
            Submit();
            Debug.Log(_playerUsernameInput.text + _playerScore);
            //Callback(true);
        }


        private void Submit()
        {
            if (!string.IsNullOrEmpty(_playerUsernameInput.text))
            {
                LeaderboardCreator.UploadNewEntry(_leaderboardPublicKey, _playerUsernameInput.text, _playerScore, Callback);
            }
            else
            {
                Debug.Log("User name is required");
            }
        }

        private void Callback(bool success)
        {
            if (success)
            {
                Debug.Log("Success");
                PlayerNameInput.SetActive(false);
                SubmitButton.SetActive(false);
                SuccessMessage.SetActive(true);
                MainMenuButton.SetActive(true);
                
            }
        }

        public void GoToMainMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}

