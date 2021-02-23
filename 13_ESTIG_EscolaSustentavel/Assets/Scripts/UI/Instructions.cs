using Database;
using Database.Model;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{
    public Text objective;
    private int _rendered = 0;
    private DatabaseManager _databaseManager;
    private void Start()
    {
        _databaseManager = gameObject.AddComponent<DatabaseManager>();
    }

    private void Update()
    {
        if (_rendered == 0)
        {
            GenericInfo objectiveInfo = _databaseManager.GetGenericInfo(7);
            objective.text = objectiveInfo.Content;
            _rendered = 1;
        }
    }

}

//  public Transform Instruction;

//   void OnTriggerEnter(Collider other)
//   {
//       Instruction.gameObject.SetActive(true);
//   }

//   void OnTriggerExit(Collider other)
//   {
//       Instruction.gameObject.SetActive(false);

//   }