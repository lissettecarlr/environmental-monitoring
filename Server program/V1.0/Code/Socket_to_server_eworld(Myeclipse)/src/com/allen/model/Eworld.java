package com.allen.model;


/////////////////////////////////////////////
//////////作为父类，设备号和设备类型以及电量可以作为让子类继承的变量。
/////////////////////////////////////////////
public class Eworld {
	private String eId;	//设备号
	private int eType;	//设备类型
//	private int eData;	//设备数据
	private int ePower;	//设备电量
	public String geteId() {
		return eId;
	}
	public void seteId(String eId2) {
		this.eId = eId2;
	}
	public int geteType() {
		return eType;
	}
	public void seteType(int eType) {
		this.eType = eType;
	}
/*	public int geteData() {
		return eData;
	}
	public void seteData(int eData) {
		this.eData = eData;
	}*/
	public int getePower() {
		return ePower;
	}
	public void setePower(int ePower) {
		this.ePower = ePower;
	}
	
}

