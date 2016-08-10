package com.allen.server.socketByteDeal;

import com.allen.model.Eworld;

public interface SocketByteDeal {
	public abstract void Deal(byte[] bstream,int socketID) throws Exception;//将接收到的数据处理，然后传入数据库
	public abstract boolean Chick(byte[] bstream,int byteNumber) throws Exception;//先进行校验，看数据是不是完整的一帧数据，是返回true

}