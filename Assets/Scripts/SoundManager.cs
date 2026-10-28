using UnityEngine;
//BGMタイプ
public enum BGMType
{
    None,       //なし
    Title,      //タイトル
    InGame,     //ゲーム中
    InBoss,     //ボス戦
}
//SEタイプ
public enum SEType
{
    GameClear,  //ゲームクリア
    GameOver,   //ゲームオーバ
    Shoot,      //矢を射る
    DoorOpen,   //ドア開く
    DoorClosed, //ドア閉じている
    ItemGet,    //アイテムゲット
    GetDamage,  //ダメージ
    EnemyKilled,//敵死亡
}
public class SoundManager : MonoBehaviour
{
    [SerializeField] public AudioClip _bgmInTitle;    //タイトルBGM
    [SerializeField] public AudioClip _bgmInGame;     //ゲーム中
    [SerializeField] public AudioClip _bgmInBoss;     //ボス戦BGM

    [SerializeField] public AudioClip _meGameClear;   //ゲームクリア
    [SerializeField] public AudioClip _meGameOver;    //ゲームオーバー
    [SerializeField] public AudioClip _seShoot;       //矢を射る

    [SerializeField] public AudioClip _seDoorOpen;    //ドア開く
    [SerializeField] public AudioClip _seDoorClosed;  //ドア閉まっている
    [SerializeField] public AudioClip _seItemGet;     //アイテムゲット
    [SerializeField] public AudioClip _seDamage;      //ダメージ
    [SerializeField] public AudioClip _seEnemyDead;   //敵死亡

    public static SoundManager soundManager;        // SoundManagerを保存する変数
    public static BGMType playing = BGMType.None;   // 再生中のBGM

    void Awake()
    {
        //BGM再生
        if (soundManager == null)
        {
            soundManager = this;  //static変数に自分を保存する
            //シーンが変わってもゲームオブジェクトを破棄しない
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);//ゲームオブジェクトを破棄
        }
    }

    //BGM設定
    public void PlayBgm(BGMType type)
    {
        if (type != playing)
        {
            playing = type;
            AudioSource audio = GetComponent<AudioSource>();
            if (type == BGMType.Title)
            {
                audio.clip = _bgmInTitle;    //タイトル
            }
            else if (type == BGMType.InGame)
            {
                audio.clip = _bgmInGame;     //ゲーム中
            }
            else if (type == BGMType.InBoss)
            {
                audio.clip = _bgmInBoss;     //ボス戦
            }
            audio.Play();
        }
    }
    //BGM停止
    public void StopBgm()
    {
        GetComponent<AudioSource>().Stop();
        playing = BGMType.None;
    }

    //SE再生
    public void SEPlay(SEType type)
    {
        if (type == SEType.GameClear)
        {
            GetComponent<AudioSource>().PlayOneShot(_meGameClear);   //ゲームクリア
        }
        else if (type == SEType.GameOver)
        {
            GetComponent<AudioSource>().PlayOneShot(_meGameOver);   //ゲームオーバー
        }
        else if (type == SEType.Shoot)
        {
            GetComponent<AudioSource>().PlayOneShot(_seShoot);       //矢を射る
        }

        else if (type == SEType.DoorClosed)
        {
            GetComponent<AudioSource>().PlayOneShot(_seDoorClosed);  //ドア閉まっている
        }
        else if (type == SEType.DoorOpen)
        {
            GetComponent<AudioSource>().PlayOneShot(_seDoorOpen);    //ドア開く
        }
        else if (type == SEType.ItemGet)
        {
            GetComponent<AudioSource>().PlayOneShot(_seItemGet);     //アイテムゲット
        }
        else if (type == SEType.GetDamage)
        {
            GetComponent<AudioSource>().PlayOneShot(_seDamage);      //ダメージ
        }
        else if (type == SEType.EnemyKilled)
        {
            GetComponent<AudioSource>().PlayOneShot(_seEnemyDead);   //敵死亡
        }
    }
}
