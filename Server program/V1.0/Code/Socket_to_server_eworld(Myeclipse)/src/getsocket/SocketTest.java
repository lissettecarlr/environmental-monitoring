package getsocket;
import java.net.*;
import java.io.*;

import com.allen.server.socketManager.SocketManager;
import com.allen.server.socketManagerImpl.SocketManagerImpl;
 



public class SocketTest extends Thread{

	
	ServerSocket server = null; //服务器的操作
	Socket scwifi = null;	    //客户端的操作
	BufferedReader bi  = null;  //读取的数据流
	PrintWriter pwt = null;		//写数据到wifi模块
	
/*	InputStream is = null;
	OutputStream os = null;*/
	
	int theSize = 20;			//定义data的字节数大小
	int getSizeCounter = 0;		//定义接收到的数据大小

	String getDataTest = new String();
	///////////////////////////////////////////////
	//////////下面是绑定socket编号和设备编号
	//////////////////////////////////////////////
	public static SocketToFac[] sockettofac = new SocketToFac[10];
	public static int counterSocket = 0;//一共连接进来的socket暂时设置最多10个
/*	public static 	Socket[] socketNumber = new Socket[10];	//socket编号
	public static int[] FaitityNumber = new int[10];	//设备编号
*/	
	public SocketTest()
	{
		
		try
		{
			server = new ServerSocket(1111);//打开1111通道
			System.out.println("Server open success~s");
		}
		catch(IOException e)
		{
			e.printStackTrace();//连接出错
			System.out.println("Init port fail");
		}
	}
	
	public void run()
	{
		while(true)											//一直监听接入的wifi模块
		{
			System.out.println("Listennin...");
			try 
			{
				sockettofac[counterSocket].socket = server.accept();//接收到了连接
				
//				scwifi = server.accept();
//				sockettofac[counterSocket].socket = scwifi;
				sockettofac[counterSocket].SocketID = counterSocket;//将得到的连接的ID记录下来
				System.out.println("Get access~"+sockettofac[counterSocket].socket.getInetAddress());
				ServerThread th = new ServerThread(sockettofac[counterSocket]);//将获得的连接传入线程
				th.start();
				
				counterSocket++;//获得一个socket连接
				
				System.out.println("Finish one Thread.");
//				sleep(1000);								//需要验证到底需不需要sleep
			} 
			catch (Exception e) 
			{
				e.printStackTrace();
			}
		}
	}
	
	
	public static void main(String[] args)
	{
		for(int i = 0;i<10;i++)//初始化SocketToFac数组
			sockettofac[i] = new SocketToFac();
		new SocketTest().start();
	}
	
	
	class ServerThread extends Thread		//再开一个线程去处理wifi模块与服务器通讯，需要吗？
	{
		Socket sk = null;		//socket对象
		int SocketID = 0;		//socketID
		
		public ServerThread(SocketToFac sktofac)
		{
			this.sk  = sktofac.socket;
			SocketID = sktofac.SocketID;
		}
		public void run()
		{
			try {
				boolean connect = true;						//连接成功了的
				byte getData[] = new byte[theSize];			//建立一个20个字节的bao
				InputStream isTemplet = null;
				OutputStream osTemplet = null;
				while(true)
				{
				int getSizeCounterNow = getSizeCounter;	
				try{
					osTemplet = sk.getOutputStream();
	//				osTemplet = sockettofac[0].socket.getOutputStream();//用同一个socket接收用来测试
					isTemplet = sk.getInputStream();		//得到wifi模块接收数据的数据流
					sk.sendUrgentData(0xff);				//一直发送紧急数据检查是否连接
					System.out.println("Connecting...");
				}
				catch(IOException e)
				{
					e.printStackTrace();
					System.out.println("Broken in 1.1");
					connect = false;
					break;
				}
				if(sk.isConnected())					//需要先判断是否还在连接中在进行数据的发送
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
				////////////////在下面写将接入到的数据存入数据库的函数
				////////////////////////////////////////////////////
				
				SocketManager skm  = new SocketManagerImpl();
				skm.Add(getData,SocketID);
				/*测试用户给命令的代码*/
				System.out.println(counterSocket);

					byte[] order = {0x01,0x02,0x03,0x04};
					if(!skm.GiveOrder(sockettofac[SocketID].FaitityNumber, order))//向发来的设备发送order
						System.out.println("Order Fail");
					System.out.println(sockettofac[SocketID].FaitityNumber+"///"+sockettofac[SocketID].SocketID);
				
				////////////////////////////////////////////////////
				///////////
				////////////////////////////////////////////////////
				
				System.out.println(getSizeCounterNow);	//打印出接收到的数据个数
				if(sk.isConnected())					//需要先判断是否还在连接中在进行数据的发送
				{
					try{
						sk.sendUrgentData(0);			//一直发送紧急数据检查是否连接,如果是连接了的就继续发送数据

					}
					catch(IOException e)
					{
//						e.printStackTrace();
						System.out.println("Broken in 3.1");
						connect = false;
						break;
					}
					try										//捕获发送字节时候的异常
					{
						osTemplet.write(getData);			//向客户端发送数据
						osTemplet.flush();
					}
					catch(IOException e)
					{
						connect = false;
						e.printStackTrace();
						System.out.println("Broken in 4.1");
					}

				}
					if(connect == false)//如果客户端断线，就跳出死循环
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
			/////////////////////////直接清空之前的socket
			//////////////////////////////////
			sockettofac[SocketID].FaitityNumber = 0;
			sockettofac[SocketID].socket = null;
			sockettofac[SocketID].SocketID = 0;
				System.out.println("Done!");
			}
		
		
		
	}
	
}
