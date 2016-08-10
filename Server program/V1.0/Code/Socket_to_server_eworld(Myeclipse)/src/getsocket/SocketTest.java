package getsocket;
import java.net.*;
import java.io.*;

import com.allen.server.socketManager.SocketManager;
import com.allen.server.socketManagerImpl.SocketManagerImpl;
 



public class SocketTest extends Thread{

	
	ServerSocket server = null; //�������Ĳ���
	Socket scwifi = null;	    //�ͻ��˵Ĳ���
	BufferedReader bi  = null;  //��ȡ��������
	PrintWriter pwt = null;		//д���ݵ�wifiģ��
	
/*	InputStream is = null;
	OutputStream os = null;*/
	
	int theSize = 20;			//����data���ֽ�����С
	int getSizeCounter = 0;		//������յ������ݴ�С

	String getDataTest = new String();
	///////////////////////////////////////////////
	//////////�����ǰ�socket��ź��豸���
	//////////////////////////////////////////////
	public static SocketToFac[] sockettofac = new SocketToFac[10];
	public static int counterSocket = 0;//һ�����ӽ�����socket��ʱ�������10��
/*	public static 	Socket[] socketNumber = new Socket[10];	//socket���
	public static int[] FaitityNumber = new int[10];	//�豸���
*/	
	public SocketTest()
	{
		
		try
		{
			server = new ServerSocket(1111);//��1111ͨ��
			System.out.println("Server open success~s");
		}
		catch(IOException e)
		{
			e.printStackTrace();//���ӳ���
			System.out.println("Init port fail");
		}
	}
	
	public void run()
	{
		while(true)											//һֱ���������wifiģ��
		{
			System.out.println("Listennin...");
			try 
			{
				sockettofac[counterSocket].socket = server.accept();//���յ�������
				
//				scwifi = server.accept();
//				sockettofac[counterSocket].socket = scwifi;
				sockettofac[counterSocket].SocketID = counterSocket;//���õ������ӵ�ID��¼����
				System.out.println("Get access~"+sockettofac[counterSocket].socket.getInetAddress());
				ServerThread th = new ServerThread(sockettofac[counterSocket]);//����õ����Ӵ����߳�
				th.start();
				
				counterSocket++;//���һ��socket����
				
				System.out.println("Finish one Thread.");
//				sleep(1000);								//��Ҫ��֤�����費��Ҫsleep
			} 
			catch (Exception e) 
			{
				e.printStackTrace();
			}
		}
	}
	
	
	public static void main(String[] args)
	{
		for(int i = 0;i<10;i++)//��ʼ��SocketToFac����
			sockettofac[i] = new SocketToFac();
		new SocketTest().start();
	}
	
	
	class ServerThread extends Thread		//�ٿ�һ���߳�ȥ����wifiģ���������ͨѶ����Ҫ��
	{
		Socket sk = null;		//socket����
		int SocketID = 0;		//socketID
		
		public ServerThread(SocketToFac sktofac)
		{
			this.sk  = sktofac.socket;
			SocketID = sktofac.SocketID;
		}
		public void run()
		{
			try {
				boolean connect = true;						//���ӳɹ��˵�
				byte getData[] = new byte[theSize];			//����һ��20���ֽڵ�bao
				InputStream isTemplet = null;
				OutputStream osTemplet = null;
				while(true)
				{
				int getSizeCounterNow = getSizeCounter;	
				try{
					osTemplet = sk.getOutputStream();
	//				osTemplet = sockettofac[0].socket.getOutputStream();//��ͬһ��socket������������
					isTemplet = sk.getInputStream();		//�õ�wifiģ��������ݵ�������
					sk.sendUrgentData(0xff);				//һֱ���ͽ������ݼ���Ƿ�����
					System.out.println("Connecting...");
				}
				catch(IOException e)
				{
					e.printStackTrace();
					System.out.println("Broken in 1.1");
					connect = false;
					break;
				}
				if(sk.isConnected())					//��Ҫ���ж��Ƿ����������ڽ������ݵķ���
				{
					try
					{
						getSizeCounterNow = isTemplet.read(getData, 0, 20);
						
					}
					catch(IOException e)
					{
						e.printStackTrace();
						System.out.println("Broken in 2.1(read)");
						connect = false;
						break;
					}
				}
				/////////////////////////////////////////////////////
				////////////////������д�����뵽�����ݴ������ݿ�ĺ���
				////////////////////////////////////////////////////
				
				SocketManager skm  = new SocketManagerImpl();
				skm.Add(getData,SocketID);
				/*�����û�������Ĵ���*/
				System.out.println(counterSocket);

					byte[] order = {0x01,0x02,0x03,0x04};
					if(!skm.GiveOrder(sockettofac[SocketID].FaitityNumber, order))//�������豸����order
						System.out.println("Order Fail");
					System.out.println(sockettofac[SocketID].FaitityNumber+"///"+sockettofac[SocketID].SocketID);
				
				////////////////////////////////////////////////////
				///////////
				////////////////////////////////////////////////////
				
				System.out.println(getSizeCounterNow);	//��ӡ�����յ������ݸ���
				if(sk.isConnected())					//��Ҫ���ж��Ƿ����������ڽ������ݵķ���
				{
					try{
						sk.sendUrgentData(0);			//һֱ���ͽ������ݼ���Ƿ�����,����������˵ľͼ�����������

					}
					catch(IOException e)
					{
//						e.printStackTrace();
						System.out.println("Broken in 3.1");
						connect = false;
						break;
					}
					try										//�������ֽ�ʱ����쳣
					{
						osTemplet.write(getData);			//��ͻ��˷�������
						osTemplet.flush();
					}
					catch(IOException e)
					{
						connect = false;
						e.printStackTrace();
						System.out.println("Broken in 4.1");
					}

				}
					if(connect == false)//����ͻ��˶��ߣ���������ѭ��
					{
						isTemplet.close();
						break;				
					}
				}	
			} catch (Exception e) {
				e.printStackTrace();
				System.out.println("Broken in 5.1");
			}
			///////////////////////////////////
			/////////////////////////ֱ�����֮ǰ��socket
			//////////////////////////////////
			sockettofac[SocketID].FaitityNumber = 0;
			sockettofac[SocketID].socket = null;
			sockettofac[SocketID].SocketID = 0;
				System.out.println("Done!");
			}
		
		
		
	}
	
}
