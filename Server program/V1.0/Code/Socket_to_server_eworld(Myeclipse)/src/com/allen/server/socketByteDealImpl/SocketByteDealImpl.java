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
		eId = (bstream[2] & 0xff)<<24 | (bstream[3]  & 0xff)<<16 | (bstream[4]  & 0xff)<<8 | (bstream[5]  & 0xff);		//�豸��
		int eType = (bstream[6] & 0xff);	//�豸����

		getsocket.SocketTest.sockettofac[socketID].FaitityNumber = eId;//�洢�����˵�socket���豸���
		////////////////////////////////////////////////
		//////////////������ȷ���豸�ľ������ã�Ȼ����ܾ���Ľ������ֽ�ת��Ϊ��Ӧ�����ݴ������ݿ�
		//////////////
		//////////////�����ȼ�������,��Ϊ4���豸��3�������漰��С���������ȼ�������λ
		////////////////////////////////////////////////
		
		int i = 1;								//����bstream[8]��λ��
		int  bstream8templt = bstream[8]&0xff;
		while((bstream8templt/10)!=0)
		{
			bstream8templt=bstream8templt/10;
			i++;
		}


		float decimalData ;																//���float��С��ֵ
		int intData = (bstream[7]&0xff)<<8|(bstream[8]&0xff);							 //�����������
		int ePower = (bstream[9] & 0xff);												 //�豸����	
//		System.out.println(tOrHdata);
//		System.out.println(Integer.toHexString((int)bstream[0]));	
		
		System.out.println(Integer.toBinaryString(eType));
		switch((eType))
		{
			

				case eIdT:				//�¶�
					decimalData = (float) ((bstream[7]&0xff)+(bstream[8]&0xff)/Math.pow(10,i));//���float��С��ֵ
					
					EworldTemperayure et = new EworldTemperayure();
					et.seteId(Integer.toHexString(eId));
					et.seteType(eType);
					et.seteData(decimalData);
					et.setePower(ePower);
					/////////////////////////
					/////����Dao
					////////////////////////
					if(skdao.SaveTem(et))
						System.out.println("Temperayure Dao success");
					else
						System.out.println("Temperayure Dao fail");
					
					break;
				case eIdH:			//ʪ��
					decimalData = (float) ((bstream[7]&0xff)+(bstream[8]&0xff)/Math.pow(10,i));//���float��С��ֵ
					
					EworldHumidity eh = new EworldHumidity();
					eh.seteId(Integer.toHexString(eId));
					eh.seteData(decimalData);
					eh.setePower(ePower);
					/////////////////////////
					/////����Dao
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
				/////����Dao
				////////////////////////
				if(skdao.SaveCO2(eco2))
					System.out.println("CO2 Dao success");
				else
					System.out.println("CO2 Dao fail");
				
				break;
				
			case eIdZPH01:
				decimalData = (float) ((bstream[7]&0xff)+(float)(bstream[8]&0xff)/100);//���float��С��ֵ
				
				EworldDust edust = new EworldDust();
				edust.seteId(Integer.toHexString(eId));
				edust.seteData(decimalData);
				edust.setePower(ePower);
				/////////////////////////
				/////����Dao
				////////////////////////
				
				if(skdao.SaveDust(edust))
					System.out.println("ZPH01 Dao success");
				else
					System.out.println("ZPH01 Dao fail");
				
				break;

				
			case eIdDSHCHO:
				decimalData = (float) ((bstream[7]&0xff)+(bstream[8]&0xff)/100);//���float��С��ֵ
				
				EworldFormaldehyde eFormal = new EworldFormaldehyde();
				eFormal.seteId(Integer.toHexString(eId));
				eFormal.seteData(decimalData);
				eFormal.setePower(ePower);
				/////////////////////////
				/////����Dao
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
		
		
		
		
		
//		int eData;	//�豸����

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
