#include "HMI.h"

HMI::HMI(USART &HMI_com):COM(HMI_com)
{}

bool HMI::setTextBox(char *ControlsName,char *Content)
{
	u8 FF[3]={0xff,0xff,0xff};
	COM<<ControlsName<<".txt="<<'"'<<Content<<'"';
	COM.SendData(FF,3);
	return 1;
}

bool HMI::setTextBox(char *ControlsName,int val)
{
	u8 FF[3]={0xff,0xff,0xff};
	char str[36];
	sprintf(str,"%d",val); 
	COM<<ControlsName<<".txt="<<'"'<<str<<'"';
	COM.SendData(FF,3);
	return 1;
}

bool HMI::setTextBox(char *ControlsName,float val,u8 decimals)
{
	u8 FF[3]={0xff,0xff,0xff};
	char str[20];
	if(decimals==1)
	sprintf(str,"%.1f",val); 
	else if(decimals==2)
	sprintf(str,"%.2f",val); 	
	else if(decimals==0)
	{
		sprintf(str,"%.0f",val); 
	}
	else
	{
	
	}
	
	COM<<ControlsName<<".txt="<<'"'<<str<<'"';
	COM.SendData(FF,3);
	return 1;
	
}

bool HMI::flushPage(char *page)
{
	u8 FF[3]={0xff,0xff,0xff};
	COM<<"page"<<" "<<page;
	COM.SendData(FF,3);
	return 1;
}

bool HMI::vis(char *ControlsName,bool state)
{
	u8 FF[3]={0xff,0xff,0xff};
	if(state == 1)
	{
		COM<<"vis "<<ControlsName<<",1";
	}
	else
	{
		COM<<"vis "<<ControlsName<<",0";
	}
	COM.SendData(FF,3);
	return 1;
}

bool HMI::outputDirection(char *ControlsName,u8 direction)
{
	
	if(direction==1)
	{
		setTextBox(ControlsName,"����"); //这儿是ASCII编码，KEIL是UTF-8所以看不到
		return true;
	}
	else if(direction==2)
	{
		setTextBox(ControlsName,"����");
		return true;
	}
	else if(direction==3)
	{
		setTextBox(ControlsName,"����");
		return true;
	}
	else if(direction==4)
	{
		setTextBox(ControlsName,"����");
		return true;
	}
	else if(direction==5)
	{
		setTextBox(ControlsName,"����");
		return true;
	}		
	else if(direction==6)
	{
		setTextBox(ControlsName,"����");
		return true;
	}		
	else if(direction==7)
	{
		setTextBox(ControlsName,"����");
		return true;
	}		
	else if(direction==8)
	{
		setTextBox(ControlsName,"����");
		return true;
	}
	else if(direction==9)
	{
		setTextBox(ControlsName,"����");
		return true;
	}
		else
			return false;						
}
