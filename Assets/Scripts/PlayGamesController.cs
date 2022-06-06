/*using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayGamesController : MonoBehaviour
{
    // [SerializeField] Text debugtext;
    // [SerializeField] InputField leaderboard;
    // [SerializeField] InputField datatocloud;
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }
    public void Initialize()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
            .RequestServerAuthCode(false).
            EnableSavedGames().
            Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        Debug.Log("playgames initialized");
        SignInWithPlayGames();
    }
    void SignInWithPlayGames()
    {
        PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptOnce, (success) =>
        {
            switch (success)
            {
                case SignInStatus.Success:
                    Debug.Log("signined in player using play games successfully");
                    break;
                default:
                    Debug.Log("Signin not successfull");
                    break;
            }
        });
    }

    public void LogOutFromPlayGames()
    {
        PlayGamesPlatform.Instance.SignOut();
    }

    public void LogOutAndLogIn()
    {
        LogOutFromPlayGames();
        Initialize();

    }

    //public void postscoretoleaderboard()
    //{
    //    Social.ReportScore(int.Parse(leaderboard.text), "CgkIzN21ycISEAIQAg", (bool success) =>
    //    {
    //        if (success)
    //        {
    //            debugtext.text = "successfully add score to leaderboard";
    //        }
    //        else
    //        {
    //            debugtext.text = "not successfull";
    //        }
    //    });
    //}
    //public void ShowLeaderboard()
    //{
    //    Social.ShowLeaderboardUI();
    //}
    //public void AchievementCompleted()
    //{
    //    Social.ReportProgress("CgkIzN21ycISEAIQAw", 100.0f, (bool success) =>
    //    {
    //        if (success)
    //        {
    //            debugtext.text = "successfully unlocked achievements";
    //        }
    //        else
    //        {
    //            debugtext.text = "not successfull";
    //        }
    //    });
    //}
    //public void ShowAchievementUI()
    //{
    //    Social.ShowAchievementsUI();
    //}

    //cloud saving
    private bool issaving = false;
    private string SAVE_NAME = "SavedGames";
    public void ReadOrSaveToCloud(bool saving)
    {
        if (Social.localUser.authenticated)
        {
            issaving = saving;
            ((PlayGamesPlatform)Social.Active).SavedGame.OpenWithAutomaticConflictResolution
                (SAVE_NAME, GooglePlayGames.BasicApi.DataSource.ReadCacheOrNetwork,
                ConflictResolutionStrategy.UseLongestPlaytime, OpenSavedGame);
        }
    }

    private void OpenSavedGame(SavedGameRequestStatus status, ISavedGameMetadata meta)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            if (issaving)//if is saving is true we are saving our data to cloud
            {
                byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(GetDataToStoreinCloud());
                SavedGameMetadataUpdate update = new SavedGameMetadataUpdate.Builder().Build();
                ((PlayGamesPlatform)Social.Active).SavedGame.CommitUpdate(meta, update, data, SaveCallback);
            }
            else//if is saving is false we are opening our saved data from cloud
            {
                ((PlayGamesPlatform)Social.Active).SavedGame.ReadBinaryData(meta, ReadDataFromCloud);
            }
        }
    }

    private void ReadDataFromCloud(SavedGameRequestStatus status, byte[] data)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            string savedata = System.Text.ASCIIEncoding.ASCII.GetString(data);
            LoadDataFromCloudToOurGame(savedata);
        }
    }

    private void LoadDataFromCloudToOurGame(string savedata)
    {
        int level = int.Parse(savedata);
        Debug.Log (level);

    }

    private void SaveCallback(SavedGameRequestStatus status, ISavedGameMetadata meta)
    {
        //use this to debug whether the game is uploaded to cloud
        Debug.Log ( "successfully add data to cloud" );
    }

    private string GetDataToStoreinCloud()//  we seting the value that we are going to store the data in cloud
    {
        string Data = "";
        int level = SceneManager.GetActiveScene().buildIndex + 1;
        Data += level;
        return Data;
    }
}
*/