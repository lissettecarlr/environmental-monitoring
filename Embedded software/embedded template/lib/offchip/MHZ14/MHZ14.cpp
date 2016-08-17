#include "MHZ14.h"

MHZ14::MHZ14(USART &com,double timeout)
:COM(com)
{
	//一帧数据读取指令
	Command_getvalue[0]=0xff;
	Command_getvalue[1]=0x01;
	Command_getvalue[2]=0x86;
	Command_getvalue[3]=0;
	Command_getvalue[4]=0;
	Command_getvalue[5]=0;
	Command_getvalue[6]=0;
	Command_getvalue[7]=0;
	Command_getvalue[8]=0x79;
	
	Timeout = timeout;
}


bool MHZ14::SumCheck(u8 data[9])
{
    u8 sum=0,check=0;	
	for(u8 i=1;i<8;i++)
	{
		sum+=data[i];
	}
     check=0xff-sum+0x01;
	if(data[8]==check)
		return true ;
	else
		return false;
}

float MHZ14::GetFloatData()
{
	return (float)CO2_Concentration;
}


unsigned char MHZ14::Updata()
{	
	double OldTime=0;
	u8 rev_buffer[9]; //接收缓存
	
	//向模块发送获取数据
	   COM.SendData(Command_getvalue,9);
		OldTime=tskmgr.Time();
	//判断是否有数据返回
	while(COM.ReceiveBufferSize()<9) 
	{
		if(tskmgr.Time() - OldTime >= Timeout)
		{
		  COM.ClearReceiveBuffer(); //清空接收缓存
		  return 2;//超时
		}
	}

		COM.GetReceivedData(rev_buffer,9); //取出一帧数据
		COM.ClearReceiveBuffer(); //清空接收缓存
		  
		if(SumCheck(rev_buffer)==false)  //校验和
			  return 3;//校验错误
		else
		 {
			  CO2_Concentration=rev_buffer[2]*256+rev_buffer[3];  //计算浓度
			  return 1;//更新成功
		 }
}

