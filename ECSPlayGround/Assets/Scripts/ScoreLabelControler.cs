using UnityEngine;
using UnityEngine.UI;


public class ScoreLabelControler : MonoBehaviour
{
    Text textScore;

    void Awake()
    {
        textScore = GetComponent<Text>();
    }

    void Start()
    {
        var context = Contexts.sharedInstance.gameState;

        context.GetGroup(GameStateMatcher.Score).OnEntityAdded += (group, entity, index, component) =>
        {
            textScore.text = "Score: " + entity.score.value;
        };
    }
}

