using System;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace LocationTracker
{
    internal class MqttBroker
    {
        private string host;
        private int port;
        private bool secure;
        private MqttSslProtocols sslprotocol;
        private MqttProtocolVersion protocolversion;
        private string username;
        private string password;

        public MqttClient _client { get; set; }

        public MqttBroker(string host, int port, bool secure, MqttSslProtocols sslprotocol, MqttProtocolVersion protocolversion, string username, string password)
        {
            this.host = host;
            this.port = port;
            this.secure = secure;
            this.sslprotocol = sslprotocol;
            this.protocolversion = protocolversion;
            this.username = username;
            this.password = password;

            Initialize();
        }

        private void Initialize()
        {
            this._client = new MqttClient(this.host, this.port, this.secure, this.sslprotocol);
            this._client.ProtocolVersion = this.protocolversion;
            this._client.MqttMsgPublished += _client_MqttMsgPublished;
            this._client.MqttMsgPublishReceived += _client_MqttMsgPublishReceived;
            
        }

        private void _client_MqttMsgPublishReceived(object sender, uPLibrary.Networking.M2Mqtt.Messages.MqttMsgPublishEventArgs e)
        {
            int j = 0;
        }

        private void _client_MqttMsgPublished(object sender, uPLibrary.Networking.M2Mqtt.Messages.MqttMsgPublishedEventArgs e)
        {
            int k = 00;
        }

        internal void Connect()
        {
            if(this._client == null || !this._client.IsConnected)
            {
                Initialize();
            }
            try
            {
                this._client.Connect(Guid.NewGuid().ToString(), this.username, this.password);
            }
            catch(Exception ex)
            {
                int k = 1;
            }
        }

        internal void Disconnect()
        {
            this._client.Disconnect();
        }

        internal void Publish(string text, byte[] v)
        {
            if(this._client == null)
            {
                Initialize();
            }
            if(!this._client.IsConnected)
            {
                Connect();
            }
            ushort messageid = this._client.Publish(text, v, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,false);
        }
    }
}