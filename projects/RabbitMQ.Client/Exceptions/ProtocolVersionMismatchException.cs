// This source code is dual-licensed under the Apache License, version
// 2.0, and the Mozilla Public License, version 2.0.
//
// The APL v2.0:
//
//---------------------------------------------------------------------------
//   Copyright (c) 2007-2025 Broadcom. All Rights Reserved.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       https://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//---------------------------------------------------------------------------
//
// The MPL v2.0:
//
//---------------------------------------------------------------------------
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.
//
//  Copyright (c) 2007-2025 Broadcom. All Rights Reserved.
//---------------------------------------------------------------------------

using System;

namespace RabbitMQ.Client.Exceptions
{
    ///<summary>Thrown to indicate that the peer does not support the
    ///wire protocol version we requested immediately after opening
    ///the TCP socket.</summary>
    [Serializable]
    public class ProtocolVersionMismatchException : ProtocolViolationException
    {
        ///<summary>Fills the new instance's properties with the values passed in.</summary>
        public ProtocolVersionMismatchException(int clientMajor,
            int clientMinor,
            int serverMajor,
            int serverMinor)
            : base($"AMQP server protocol negotiation failure: server version {positiveOrUnknown(serverMajor)}-{positiveOrUnknown(serverMinor)}, client version {positiveOrUnknown(clientMajor)}-{positiveOrUnknown(clientMinor)}")
        {
            ClientMajor = clientMajor;
            ClientMinor = clientMinor;
            ServerMajor = serverMajor;
            ServerMinor = serverMinor;
        }

        ///<summary>The client's AMQP specification major version.</summary>
        public int ClientMajor { get; }

        ///<summary>The client's AMQP specification minor version.</summary>
        public int ClientMinor { get; }

        ///<summary>The peer's AMQP specification major version.</summary>
        public int ServerMajor { get; }

        ///<summary>The peer's AMQP specification minor version.</summary>
        public int ServerMinor { get; }

        private static string positiveOrUnknown(int version)
        {
            return version >= 0 ? version.ToString() : "unknown";
        }
    }
}
