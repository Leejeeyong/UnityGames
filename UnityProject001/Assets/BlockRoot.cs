using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRoot : MonoBehaviour {
    public GameObject BlockPrefab = null;
    public BlockControl[,] blocks;
    private GameObject main_camera = null;
    private BlockControl grabbed_block = null;

	// Use this for initialization
	void Start () {
        this.main_camera = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mouse_position;
        this.unprojectMousePosition(out mouse_position, Input.mousePosition);

        Vector2 mouse_position_xy = new Vector2(mouse_position.x, mouse_position.y);

        if (this.grabbed_block == null){ //잡은 블럭이 비었으면
            //if (!this.is_has_falling_block()){
            if (Input.GetMouseButtonDown(0)){ //마우스버튼이 눌렸으면
                foreach(BlockControl block in this.blocks){
                    if (!block.isGrabbable()){//블럭을 잡을수 없다면
                        continue;//루프의 처음으로
                    }

                    if (!block.isContainedPosition(mouse_position_xy)){//마우스위치가 블록영역안이 아니라면
                        continue;//루프의 처음으로
                    }
                    this.grabbed_block = block;
                    this.grabbed_block.beginGrab();
                    break;
                }
            }

            //}
        }
        else{
            if (!Input.GetMouseButton(0)){
                this.grabbed_block.endGrab();
                this.grabbed_block = null;
            }
        }

	}

    //블록만들어서 9x9로 배치한다.
    public void initialSetup(){
        //그리드 크기를 9x9로 한다
        this.blocks =
            new BlockControl[Block.BLOCK_NUM_X, Block.BLOCK_NUM_Y];
        int color_index = 0;

        for(int y = 0; y < Block.BLOCK_NUM_Y; y++){//행
            for(int x=0; x < Block.BLOCK_NUM_X; x++){//열
                //BlockPrefab을 인스턴스 씬에 만든다
                GameObject game_object =
                    Instantiate(this.BlockPrefab) as GameObject;
                //위에서 만든 블럭의 BlockControl클래스를 가져온다.
                BlockControl block = game_object.GetComponent<BlockControl>();
                //블록을 그리드에 저장한다.
                this.blocks[x, y] = block;

                //블록의 위치정보를 설정
                block.i_pos.x = x;
                block.i_pos.y = y;
                //각 BlockControl이 연계할 GameRoot는 자신이라고 설정
                block.block_root = this;

                //그리드좌표를 실제위치로 변환
                Vector3 position = BlockRoot.calcBlockPosition(block.i_pos);
                //씬의 블록위치를 이동
                block.transform.position = position;
                //블록의 색변경
                block.setColor((Block.COLOR)color_index);
                //블록의 이름 설정
                block.name = "block(" + block.i_pos.x.ToString() + "," + block.i_pos.y.ToString() + ")";

                //전체 색중에서 임의로 하나를 선택
                color_index =
                    Random.Range(0, (int)Block.COLOR.NORMAL_COLOR_NUM);

            }
        }

    }
    public static Vector3 calcBlockPosition(Block.iPosition i_pos){

        Vector3 position = new Vector3(-(Block.BLOCK_NUM_X / 2.0f - 0.5f),-(Block.BLOCK_NUM_Y/2.0f-0.5f),0.0f);

        position.x += (float)i_pos.x * Block.COLLISION_SIZE;
        position.y += (float)i_pos.y * Block.COLLISION_SIZE;

        return (position);
    }

    public bool unprojectMousePosition(out Vector3 world_position, Vector3 mouse_position){
        bool ret;

        //판을 작성 카메라에 대해 뒤로 향해서 vector3.back
        //블록의 절반크기만큼 앞에 둔다
        Plane plane = new Plane(Vector3.back, new Vector3(0.0f, 0.0f, -Block.COLLISION_SIZE / 2.0f));
        //카메라와 마우스를 통과하는 빛을 만듦
        Ray ray = this.main_camera.GetComponent<Camera>().ScreenPointToRay(mouse_position);

        float depth;
        //광선이 판에 닿았다면
        if(plane.Raycast(ray,out depth)){
            //인수 world_position을 마우스 위치로 덮어쓴다
            world_position = ray.origin + ray.direction * depth;
            ret = true;
        }
        else{
            //인수 world_position을 0인 벡터로 덮어쓴다.
            world_position = Vector3.zero;
            ret = false;
        }

        return (ret);
    }
}
