package com.allen.model;


/////////////////////////////////////////////
//////////��Ϊ���࣬�豸�ź��豸�����Լ�����������Ϊ������̳еı�����
/////////////////////////////////////////////
public class Eworld {
	private String eId;	//�豸��
	private int eType;	//�豸����
//	private int eData;	//�豸����
	private int ePower;	//�豸����
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

