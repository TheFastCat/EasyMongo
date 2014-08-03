﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using NUnit.Framework;
using EasyMongo;
using MongoDB.Driver;
using EasyMongo.Contract;
using EasyMongo.Test.Base;

namespace EasyMongo.Async.Test
{
    [TestFixture, Ignore("Not yet implemented to reflect new asynchronous Task implementation")]
    public class ServerConnectionTest : IntegrationTestFixture
    {
        #region Asynchronous

        [Test]
        public void AsynchronousTest1()
        {
            _mongoServerConnection = new ServerConnection(MONGO_CONNECTION_STRING);
            Assert.AreEqual(MongoServerState.Disconnected, _mongoServerConnection.State);
            Assert.AreEqual(ConnectionResult.Empty,_serverConnectionResult);
            _mongoServerConnection.ConnectAsyncTask();
            System.Threading.Thread.Sleep(200);
            Assert.AreEqual(MongoServerState.Connected, _mongoServerConnection.State);
        }

        [Test]
        public void AsynchronousTest2()
        {
            _mongoServerConnection = new ServerConnection(MONGO_CONNECTION_STRING);
            Assert.AreEqual(ConnectionResult.Empty, _serverConnectionResult);
            _mongoServerConnection.ConnectAsyncDelegate(_mongoServerConnection_Connected);

            List<string> returned = _mongoServerConnection.GetDbNamesForConnection();
            Assert.AreEqual(ConnectionResult.Success, _serverConnectionResult);
            Assert.AreEqual(MongoServerState.Connected, _mongoServerConnection.State);
            Assert.IsNotNull(_serverConnectionReturnMessage);

            Assert.AreEqual(0, returned.Count(),"no database names since nothing has been written yet");
            AddMongoEntry();

            returned = _mongoServerConnection.GetDbNamesForConnection();

            Assert.AreEqual(1, returned.Count(), "only the driver-created database, local, should exist");
            Assert.AreEqual(MONGO_DATABASE_1_NAME, returned[0]);
        }

        [Test]
        public void AsynchronousTest3()
        {
            _mongoServerConnection = new ServerConnection(MONGO_CONNECTION_STRING_BAD);
            _mongoServerConnection.ConnectAsyncDelegate(_mongoServerConnection_Connected);
            _serverConnectionAutoResetEvent.WaitOne();

            Assert.AreEqual(ConnectionResult.Failure, _serverConnectionResult);
            Assert.AreEqual(MongoServerState.Disconnected, _mongoServerConnection.State);
            Assert.IsNotNull(_serverConnectionReturnMessage);
        }

        #endregion Asynchronous
    }
}
