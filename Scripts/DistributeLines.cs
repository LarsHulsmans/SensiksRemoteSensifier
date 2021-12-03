using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistributeLines : MonoBehaviour
{
    [SerializeField]
    private GameObject longTick;

    [SerializeField]
    private GameObject shortTick;

    [SerializeField]
    private GameObject tickLabel;

    [SerializeField]
    private Transform labelsHolder;

    private RectTransform trans;

    void Start()
    {
        this.trans = GetComponent<RectTransform>();

        float totalHeight = trans.rect.height;

        float tenth = totalHeight / 10;
        float fourtyth = tenth / 4;

        float startingHeight = 0 - (totalHeight / 2);


        for (int i = 0; i < 11; i++)
        {
            GameObject largeTick = GameObject.Instantiate(longTick, this.trans);
            RectTransform largeTickTrans = largeTick.GetComponent<RectTransform>();
            largeTickTrans.localPosition = new Vector2(largeTickTrans.localPosition.x, tenth * i);

            GameObject label = GameObject.Instantiate(tickLabel, labelsHolder);
            RectTransform labelTransform = label.GetComponent<RectTransform>();
            labelTransform.localPosition = new Vector2(labelTransform.localPosition.x, startingHeight + (tenth * i));
            label.GetComponent<Text>().text = (i * 10).ToString();

            if(i < 10)
            {
                for (int j = 1; j < 4; j++)
                {
                    GameObject smallTick = GameObject.Instantiate(shortTick, this.trans);
                    RectTransform smallTickTrans = smallTick.GetComponent<RectTransform>();
                    smallTickTrans.localPosition = new Vector2(smallTickTrans.localPosition.x, (tenth * i) + (fourtyth * j));
                }
            }
        }
    }

}
