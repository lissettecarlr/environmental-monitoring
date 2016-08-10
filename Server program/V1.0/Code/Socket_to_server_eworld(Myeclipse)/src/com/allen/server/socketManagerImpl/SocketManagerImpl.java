package com.allen.server.socketManagerImpl;

import java.io.IOException;
import java.io.OutputStream;

import com.allen.dao.socketDao.SocketDao;
import com.allen.model.Eworld;
import com.allen.server.socketByteDeal.SocketByteDeal;
import com.allen.server.socketByteDealImpl.SocketByteDealImpl;
import com.allen.server.socketManager.SocketManager;

public class SocketManagerImpl implements SocketManager {
	

	private SocketDao skDao;
	@Override
	public boolean Add(byte[] bstream,int socketID) throws Exception {
		
		SocketByteDeal skbd = new SocketByteDealImpl();
		/////////////////////////
		/////1`�����ֽ���,�ж��Ƿ���ϱ�׼
		////////////////////////
		
		if(skbd.Chick(bstream, 20))
		{
			System.out.println("Chick success");
		/////////////////////////
		/////2`�������ͷ�Ͱ�βͨ��������
		////////////////////////
			skbd.Deal(bstream,socketID);

		}
		else
		{
			System.out.println("Chick fail");
			return false;
		}

		

//		skDao.Save(eworld);
		return true;
	}
	@Override
	public boolean GiveOrder(int FacNumber, byte[] order) {
		System.out.println("Get into UserOrder");
		
		int SockIDTemplet = 0;//�洢��Ѱ�����豸��Ŷ�Ӧ���豸����±��socket�����±�
		OutputStream osTemplet = null;//�洢socket�������
		for(SockIDTemplet = 0;SockIDTemplet < getsocket.SocketTest.counterSocket;SockIDTemplet++)
		{
			System.out.println("FacNumber:"+FacNumber);
			if(getsocket.SocketTest.sockettofac[SockIDTemplet].FaitityNumber == FacNumber)
			{
				System.out.println("Find FacNumber:"+getsocket.SocketTest.sockettofac[SockIDTemplet].FaitityNumber);
				break;//��������Ӧ���豸������
			}
		}
		if(SockIDTemplet == getsocket.SocketTest.counterSocket)//���û����������Ӧ���豸��,Ҳ����ѭ��֮��������±�ɨ����ֵ���������е��豸����
		{
			System.out.println("Order Fail_1111111111111111111111111111");
			return false;//��������ʧ��,��Ϊû���������豸�����ӽ���
		}
		//////////////////////////////
		////////////�ж��Ƿ���������
		///////////////////////////////
		try {
			getsocket.SocketTest.sockettofac[SockIDTemplet].socket.sendUrgentData(0);
		} catch (IOException e) {
			e.printStackTrace();
			System.out.print("Not Linked");
			return false;
		}
		/////////////////////////////////
		/////////////////�����������ȥ��ø�socket���������Ȼ���ڷ��ͣ�������Ҫ��������������ط�ͬʱ�����������ʱ������ʲô���
		////////////////////////////////
		try {
			osTemplet = getsocket.SocketTest.sockettofac[SockIDTemplet].socket.getOutputStream();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		/////////////////////////////////////////////////////////////////////////
		//////////////��ʼ����ָ��
		/////////////////////////////////////////////////////////////////////////
		try										//�������ֽ�ʱ����쳣
		{
			osTemplet.write(order);			//��ͻ��˷�������
			osTemplet.flush();
		}
		catch(IOException e)
		{
			e.printStackTrace();
			return false;
		}
		return true;//˳�����֮��ͷ���
	}
	
	
	@Override
	public boolean GiveOrder(long FacNumber, byte[] order) {
		System.out.println("Get into UserOrder");
		
		int SockIDTemplet = 0;//�洢��Ѱ�����豸��Ŷ�Ӧ���豸����±��socket�����±�
		OutputStream osTemplet = null;//�洢socket�������
		for(SockIDTemplet = 0;SockIDTemplet < getsocket.SocketTest.counterSocket;SockIDTemplet++)
		{
			System.out.println("FacNumber:"+FacNumber);
			if(getsocket.SocketTest.sockettofac[SockIDTemplet].FaitityNumber == FacNumber)
			{
				System.out.println("Find FacNumber:"+getsocket.SocketTest.sockettofac[SockIDTemplet].FaitityNumber);
				break;//��������Ӧ���豸������
			}
		}
		if(SockIDTemplet == getsocket.SocketTest.counterSocket)//���û����������Ӧ���豸��,Ҳ����ѭ��֮��������±�ɨ����ֵ���������е��豸����
		{
			System.out.println("Order Fail_1111111111111111111111111111");
			return false;//��������ʧ��,��Ϊû���������豸�����ӽ���
		}
		//////////////////////////////
		////////////�ж��Ƿ���������
		///////////////////////////////
		try {
			getsocket.SocketTest.sockettofac[SockIDTemplet].socket.sendUrgentData(0);
		} catch (IOException e) {
			e.printStackTrace();
			System.out.print("Not Linked");
			return false;
		}
		/////////////////////////////////
		/////////////////�����������ȥ��ø�socket���������Ȼ���ڷ��ͣ�������Ҫ��������������ط�ͬʱ�����������ʱ������ʲô���
		////////////////////////////////
		try {
			osTemplet = getsocket.SocketTest.sockettofac[SockIDTemplet].socket.getOutputStream();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		/////////////////////////////////////////////////////////////////////////
		//////////////��ʼ����ָ��
		/////////////////////////////////////////////////////////////////////////
		try										//�������ֽ�ʱ����쳣
		{
			osTemplet.write(order);			//��ͻ��˷�������
			osTemplet.flush();
		}
		catch(IOException e)
		{
			e.printStackTrace();
			return false;
		}
		return true;//˳�����֮��ͷ���
	}


}
