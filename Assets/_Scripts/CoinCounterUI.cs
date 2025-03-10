using UnityEngine;
using System.Collections;
using DG.Tweening;
using TMPro;

public class CoinCounterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI current;
    [SerializeField] private TextMeshProUGUI toUpdate;
    [SerializeField] private Transform coinTextContainer;
    [SerializeField] private float duration;

    private float containInitPosition;
    private float moveAmount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Canvas.ForceUpdateCanvases();
        current.SetText("0");
        toUpdate.SetText("0");
        containInitPosition=coinTextContainer.localPosition.y;
        moveAmount=current.rectTransform.rect.height;
    }

    public void UpdateScore(int score){
        toUpdate.SetText($"{score}");
        coinTextContainer.DOLocalMoveY(containInitPosition+moveAmount,duration);
        StartCoroutine(ResetCoinContainer(score));
    }
    private IEnumerator ResetCoinContainer(int score){
        yield return new WaitForSeconds(duration);
        current.SetText($"{score}");
        Vector3 localPosition= coinTextContainer.localPosition;
        coinTextContainer.localPosition = new Vector3(localPosition.x,containInitPosition,localPosition.z);
    }
}
