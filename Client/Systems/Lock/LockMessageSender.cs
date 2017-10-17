﻿using LunaClient.Base;
using LunaClient.Base.Interface;
using LunaClient.Network;
using LunaCommon.Message.Client;
using LunaCommon.Message.Interface;
using System.Threading.Tasks;

namespace LunaClient.Systems.Lock
{
    public class LockMessageSender : SubSystem<LockSystem>, IMessageSender
    {
        public void SendMessage(IMessageData msg)
        {
            TaskFactory.StartNew(() => NetworkSender.QueueOutgoingMessage(MessageFactory.CreateNew<LockCliMsg>(msg)));
        }
    }
}