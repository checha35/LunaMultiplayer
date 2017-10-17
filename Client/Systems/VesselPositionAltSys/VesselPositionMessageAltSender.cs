﻿using LunaClient.Base;
using LunaClient.Base.Interface;
using LunaClient.Network;
using LunaCommon.Message.Client;
using LunaCommon.Message.Interface;
using System.Threading.Tasks;

namespace LunaClient.Systems.VesselPositionAltSys
{
    public class VesselPositionMessageAltSender : SubSystem<VesselPositionAltSystem>, IMessageSender
    {
        public void SendMessage(IMessageData msg)
        {
            TaskFactory.StartNew(() => NetworkSender.QueueOutgoingMessage(MessageFactory.CreateNew<VesselCliMsg>(msg)));
        }

        public void SendVesselPositionUpdate(Vessel vessel)
        {
            var update = new VesselPositionAltUpdate(vessel);
            TaskFactory.StartNew(() => SendVesselPositionUpdate(update));
        }

        public void SendVesselPositionUpdate(VesselPositionAltUpdate update)
        {
            SendMessage(update.AsSimpleMessage());
        }
    }
}
