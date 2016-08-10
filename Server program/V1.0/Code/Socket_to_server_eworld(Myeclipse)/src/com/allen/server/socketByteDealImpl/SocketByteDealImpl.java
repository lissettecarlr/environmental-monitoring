package com.allen.server.socketByteDealImpl;

import com.allen.dao.socketDao.SocketDao;
import com.allen.dao.socketDaoImpl.SocketDaoImpl;
import com.allen.model.Eworld;
import com.allen.model.EworldCO2;
import com.allen.model.EworldDust;
import com.allen.model.EworldFormaldehyde;
import com.allen.model.EworldHumidity;
import com.allen.model.EworldTemperayure;
import com.allen.server.socketByteDeal.SocketByteDeal;

import java.math.*;

public class SocketByteDealImpl implements SocketByteDeal {


	private final int eIdT  = 0x02;
	private final int eIdH  = 0x01;
	private final int eIdCO2    = 0x03;
	private final int eIdZPH01  = 0x04;
	private final int eIdDSHCHO = 0x05;
	private SocketDao skdao = new SocketDaoImpl();
	@Override
	public void Deal(byte[] bstream,int socketID) throws Exception {
//		Eworld eworld = new Eworld();
		int  eId = 0;
		eId = (bstream[2] & 0xff)<<24 | (bstream[3]  & 0xff)<<16 | (bstream[4]  & 0xff)<<8 | (bstream[5]  & 0xff);		//设备号
		int eType = (bstream[6] & 0xff);	//设备类型

		getsocket.SocketTest.sockettofac[socketID].FaitityNumber = eId;//存储连接了的socket的设备编号
		////////////////////////////////////////////////
		//////////////接下来确定设备的具体作用，然后才能具体的将数据字节转换为相应的数据存入数据库
		//////////////
		//////////////首先先计算数据,因为4个设备中3个都会涉及到小数，所以先计算数据位
		////////////////////////////////////////////////
		
		int i = 1;								//保存bstream[8]的位数
		int  bstream8templt = bstream[8]&0xff;
		while((bstream8templt/10)!=0)
		{
			bstream8templt=bstream8templt/10;
			i++;
		}


		float decimalData ;																//获得float的小数值
		int intData = (bstream[7]&0xff)<<8|(bstream[8]&0xff);							 //获得整型数据
		int ePower = (bstream[9] & 0xff);												 //设备电量	
//		System.out.println(tOrHdata);
//		System.out.println(Integer.toHexString((int)bstream[0]));	
		
		System.out.println(Integer.toBinaryString(eType));
		switch((eType))
		{
			

				case eIdT:				//温度
					decimalData = (float) ((bstream[7]&0xff)+(bstream[8]&0xff)/Math.pow(10,i));//获得float的小数值
					
					EworldTemperayure et = new EworldTemperayure();
					et.seteId(Integer.toHexString(eId));
					et.seteType(eType);
					et.seteData(decimalData);
					et.setePower(ePower);
					/////////////////////////
					/////调入Dao
					////////////////////////
					if(skdao.SaveTem(et))
						System.out.println("Temperayure Dao success");
					else
						System.out.println("Temperayure Dao fail");
					
					break;
				case eIdH:			//湿度
					decimalData = (float) ((bstream[7]&0xff)+(bstream[8]&0xff)/Math.pow(10,i));//获得float的小数值
					
					EworldHumidity eh = new EworldHumidity();
					eh.seteId(Integer.toHexString(eId));
					eh.seteData(decimalData);
					eh.setePower(ePower);
					/////////////////////////
					/////调入Dao
					////////////////////////
					if(skdao.SaveHum(eh))
						System.out.println("Humidity Dao success");
					else
						System.out.println("Humidity Dao fail");
					
					break;

				
			case eIdCO2:							//CO2
				
				EworldCO2 eco2 = new EworldCO2();
				eco2.seteId(Integer.toHexString(eId));
				eco2.seteData(intData);
				eco2.setePower(ePower);
				
				/////////////////////////
				/////调入Dao
				////////////////////////
				if(skdao.SaveCO2(eco2))
					System.out.println("CO2 Dao success");
				else
					System.out.println("CO2 Dao fail");
				
				break;
				
			case eIdZPH01:
				decimalData = (float) ((bstream[7]&0xff)+(float)(bstream[8]&0xff)/100);//获得float的小数值
				
				EworldDust edust = new EworldDust();
				edust.seteId(Integer.toHexString(eId));
				edust.seteData(decimalData);
				edust.setePower(ePower);
				/////////////////////////
				/////调入Dao
				////////////////////////
				
				if(skdao.SaveDust(edust))
					System.out.println("ZPH01 Dao success");
				else
					System.out.println("ZPH01 Dao fail");
				
				break;

				
			case eIdDSHCHO:
				decimalData = (float) ((bstream[7]&0xff)+(bstream[8]&0xff)/100);//获得float的小数值
				
				EworldFormaldehyde eFormal = new EworldFormaldehyde();
				eFormal.seteId(Integer.toHexString(eId));
				eFormal.seteData(decimalData);
				eFormal.setePower(ePower);
				/////////////////////////
				/////调入Dao
				////////////////////////
				if(skdao.SaveFor(eFormal))
					System.out.println("DS-HCHO  Dao success");
				else
					System.out.println("DS-HCHO  Dao fail");
				break;
				
			default:
				System.out.println("default");
				;
		}
		
		
		
		
		
//		int eData;	//设备数据

	}

	@Override
	public boolean Chick(byte[] bstream,int byteNumber) throws Exception {
		
/*		byte bchick[] = {(byte)0xff,(byte)0xaa,0x19};
//		bchick[3] = {0xff,0xaa,0x19};
		byte bchick2[] = {0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00};
		for(byte i = 0;i<8;i++)
		{
			bchick2[i] = (byte) (bstream[i]>>i);
		}*/
		System.out.println(bstream[0]+"/"+bstream[1]+"/"+bstream[19]);
		if(((bstream[0] & 0xff)==0xff) && ((bstream[1] & 0xff)==0xaa)/* && ((bstream[19] & 0xff) == 0x14)*/)
		{
			System.out.println("slave");
			return true;
		}
		if(((bstream[0] & 0xff)==0xff) && ((bstream[1] & 0xff)==0xbb)/* && ((bstream[19] & 0xff) == 0x14)*/)
		{
			System.out.println("master");
			return true;
		}
			return false;
	}

}
