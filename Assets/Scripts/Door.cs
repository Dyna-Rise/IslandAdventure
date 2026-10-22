using UnityEngine;

public class Door : MonoBehaviour
{
    private UIController _uiCnt; //UIControllerスクリプトを参照できる変数

    void Start()
    {
        //UIControllerスクリプトを探してくる
        _uiCnt = GameObject.FindFirstObjectByType<UIController>();
    }

    //接触した時
    //①相手がPlayerタグをもつものであれば
    //②鍵が1以上所持されていれば
    //・ドアは消滅 ・UIControllerの鍵テキストの更新
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(ItemKeeper.hasKeys > 0)
            {
                ItemKeeper.hasKeys--; //1減らす
                Destroy(gameObject); //ドア消滅
                _uiCnt.UpdateItemCount(ItemType.key, ItemKeeper.hasKeys); //UI更新
            }
        }
    }    　
}
