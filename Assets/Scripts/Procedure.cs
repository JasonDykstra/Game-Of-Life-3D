using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Procedure : MonoBehaviour {

    public GameObject Cube_Preset;
    public int x;
    public int y;
    public int z;
    public GameObject[,,] cells;

	// Use this for initialization
	void Start () {
        cells = new GameObject[x, y, z];
        for (int i = 0; i < x; i++) {
            for(int j = 0; j < y; j++) {
                for(int k = 0; k < z; k++) {
                    cells[i, j, k] = Instantiate(Cube_Preset, new Vector3(i, j, k), Quaternion.identity);
                }
            }
        }

        //cells[(int)(x / 2), (int)(y / 2), (int)(z / 2)].GetComponent<CubeScript>().alive = true;
        
        //foreach (GameObject cell in cells) {
        //    float rand = Random.value;
        //    if(rand >= 0.7) {
        //        cell.GetComponent<CubeScript>().nextAlive = true;
        //    }

        //}
        
        cells[(int)(x / 2), (int)(y / 2), (int)(z / 2)].GetComponent<CubeScript>().alive = true;
        cells[(int)(x / 2) + 1, (int)(y / 2), (int)(z / 2)].GetComponent<CubeScript>().alive = true;
        cells[(int)(x / 2), (int)(y / 2) + 1, (int)(z / 2)].GetComponent<CubeScript>().alive = true;
        cells[(int)(x / 2) + 1, (int)(y / 2) + 1, (int)(z / 2)].GetComponent<CubeScript>().alive = true;

    }
	
	// Update is called once per frame
	void FixedUpdate () {
		for(int c = 0; c < cells.Length; c++) {
            //2D Rules:
            //Any live cell with fewer than two live neighbours dies
            //Any live cell with two or three live neighbours lives on to the next generation
            //Any live cell with more than three live neighbours dies
            //Any dead cell with exactly three live neighbours becomes a live cell

            //trust
            //converting 1d array index to 3d array position (x_c, y_c, z_c)
            int z_c = c / (x * y);
            int y_c = (c % (x * y)) / x;
            int x_c = c % x;

            int liveCount = 0;

            //check neighbors
            for (int i = -1; i <= 1; i++) {
                for (int j = -1; j <= 1; j++) {
                    for (int k = -1; k <= 1; k++) {
                        if((i == 0 && j == 0 && k == 0) || (x_c + i < 0) || (y_c + j < 0) || (z_c + k < 0) || (x_c + i >= x) || (y_c + j >= y) || (z_c + k >= z)) {
                            continue;
                        } else if(cells[x_c + i, y_c + j, z_c + k].GetComponent<CubeScript>().alive){
                            liveCount++;
                            //print("increasing! x: " + (x_c + i) + ", y: " + (y_c + j) + ", z: " + (z_c + k) + ", alive: " + cells[x_c + i, y_c + j, z_c + k].GetComponent<CubeScript>().alive);
                        }
                    }
                }
            }

            CubeScript script = cells[x_c, y_c, z_c].GetComponent<CubeScript>();

            if (script.alive) {
                //first 3 rules
                if(liveCount != 9) {
                    script.nextAlive = false;
                } else {
                    //HAVE TO DO THIS since by default, nextAlive is false
                    script.nextAlive = true;
                }
            } else if(script.alive == false) {
                //last rule
                //if(liveCount >= 4 && liveCount <= 4) {
                if(liveCount == 4) {
                    script.nextAlive = true;
                    //print("happy");
                } else {
                    script.nextAlive = false;
                }
            }

        }

        foreach (GameObject cell in cells) {
            cell.GetComponent<CubeScript>().alive = cell.GetComponent<CubeScript>().nextAlive;
        }



        //only update once every 1 sec
        //System.Threading.Thread.Sleep(1000);
    }
}