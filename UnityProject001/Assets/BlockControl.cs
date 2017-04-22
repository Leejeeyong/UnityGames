using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block{
    public static float COLLISION_SIZE = 1.0f;//블록 충돌크기
    public static float VANISH_TIME = 3.0f; //불 붙고 사라질때까지 시간

    public struct iPosition{//그리드에서의 좌표를 나타내는 구조체
        public int x;
        public int y;
    }
    public enum COLOR{ //블록색상지정
        NONE=-1,
        PINK = 0,
        BLUE,
        YELLOW,
        GREEN,
        MAGENTA,
        ORANGE,
        GRAY,
        NUM,        //색상의 갯수
        FIRST=PINK,//초기컬러
        LAST=ORANGE,//최종컬러
        NORMAL_COLOR_NUM=GRAY,//보통컬러
    };

    public enum DIR4{ //상하좌우 방향
        NONE=-1,    //방향지정 없음
        RIGHT,
        LEFT,
        UP,
        DOWN,
        NUM,        //방향 갯수
    };

    public static int BLOCK_NUM_X = 9;//블록을 배치할수있는 x방향 최대 갯수
    public static int BLOCK_NUM_Y = 9;// 동일 y방향

    public enum STEP{//블록의 상태표시
        NONE = -1,//상태정보없음
        IDLE = 0,//대기중
        GRABBED,//잡혀있음
        RELEASED,//떨어진순간
        SLIDE,//슬라이드중
        VACANT,//소멸중
        RESPAWN,//재생성
        FALL,//낙하중
        LONG_SLIDE,//크게슬라이드
        NUM,//상태의 종류 갯수
    }

}

public class BlockControl : MonoBehaviour {
    // Use this for initialization
    public Block.COLOR color = (Block.COLOR)0;
    public BlockRoot block_root = null;
    public Block.iPosition i_pos;

    public Block.STEP step = Block.STEP.NONE;//현재
    public Block.STEP next_step = Block.STEP.NONE;//다음
    public Vector3 position_offset_initial = Vector3.zero;//교체전위치
    public Vector3 position_offset = Vector3.zero;//교체후위치

	void Start () {
        this.setColor(this.color);
        this.next_step = Block.STEP.IDLE;//다음블록을 대기
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mouse_position; //마우스 위치
        this.block_root.unprojectMousePosition(out mouse_position, Input.mousePosition);//마우스위치 획득

        //획득한 마우스 정보를 x와 y만으로 한다
        Vector2 mouse_position_xy = new Vector2(mouse_position.x, mouse_position.y);

        //다음블록상태가 정보없음 이외인 동안
        //=다음블록 상태가 변경된 경우
        while(this.next_step != Block.STEP.NONE){
            this.step = this.next_step;
            this.next_step = Block.STEP.NONE;

            switch (this.step){
                case Block.STEP.IDLE://대기상태
                    this.position_offset = Vector3.zero;
                    //블록 표시 크기를 보통으로 한다
                    this.transform.localScale = Vector3.one * 1.0f;
                    break;
                case Block.STEP.GRABBED://잡힌상태
                    //블록 표시크기를 크게한다.
                    this.transform.localScale = Vector3.one * 1.2f;
                    break;
                case Block.STEP.RELEASED://떨어져있는 상태
                    this.position_offset = Vector3.zero;
                    //블록 표시크기를 보통으로 한다
                    this.transform.localScale = Vector3.one * 1.0f;
                    break;
            }
        }

        //그리드 좌표를 실제 좌표로 변환
        //posiiton_offset을 추가
        Vector3 position = BlockRoot.calcBlockPosition(this.i_pos) + this.position_offset;
        //실제위치를 새로운 위치로 변경
        this.transform.position = position;
	}

    public void setColor(Block.COLOR color){
        this.color = color;
        Color color_value;

        switch (this.color){
            default:
            case Block.COLOR.PINK:
                color_value = new Color(1.0f, 0.5f,0.5f);
                break;
            case Block.COLOR.BLUE:
                color_value = Color.blue;
                break;
            case Block.COLOR.YELLOW:
                color_value = Color.yellow;
                break;
            case Block.COLOR.GREEN:
                color_value = Color.green;
                break;
            case Block.COLOR.MAGENTA:
                color_value = Color.magenta;
                break;
            case Block.COLOR.ORANGE:
                color_value = new Color(1.0f, 0.46f, 0.0f);
                break;
        }
        this.GetComponent<Renderer>().material.color = color_value;
    }

    public void beginGrab(){
        this.next_step = Block.STEP.GRABBED;
    }

    public void endGrab(){
        this.next_step = Block.STEP.IDLE;
    }

    public bool isGrabbable(){
        bool is_grabbable =false;
        switch (this.step){
            case Block.STEP.IDLE://대기상태일때만
                is_grabbable = true;//잡을수있다
                break;
        }

        return (is_grabbable);
    }

    public bool isContainedPosition(Vector2 position){
        bool ret = false;
        Vector3 center = this.transform.position;
        float h = Block.COLLISION_SIZE / 2.0f;

        do
        {
            //각각 x와 y좌표가 겹치지 않으면 break로 루프를 빠져나간다.
            if (position.x < center.x - h || center.x + h < position.x)
            {
                break;
            }

            if (position.y < center.y - h || center.y - h < position.y)
            {
                break;
            }
        } while (false);

        return (ret);
    }
}
