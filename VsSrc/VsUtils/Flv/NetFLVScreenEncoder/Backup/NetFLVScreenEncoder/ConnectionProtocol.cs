using System;
using System.Collections.Generic;
using System.Text;

namespace NetFLVScreenEncoder
{
    /// <summary>
    /// Abstract "protocol" wrapper to be used.
    /// </summary>
    abstract class ConnectionProtocol
    {
        public delegate void fMethodCallback(object rValue);

        /// <summary>
        /// Handles triggers of remote invocations of client-side code.
        /// </summary>
        /// <param name="invocationTarget">The invocation target "name", the name of the method.</param>
        /// <param name="methodParams">A list of parameters passed.</param>
        public delegate void fRemoteCallHandler(string invocationTarget, params object[] methodParams);

        /// <summary>
        /// Handles connection to the server in both TCP layer and higher protocol layer.
        /// </summary>
        /// <param name="c_params">List of parameters to pass to the server.</param>
        /// <returns>True if connected, false otherwise.</returns>
        abstract public bool connect(params string[] c_params);

        /// <summary>
        /// Disconnects from the server.
        /// </summary>
        /// <returns>True if disconnected happily, false if there was an error.</returns>
        abstract public bool disconnect();

        /// <summary>
        /// Returns the name of this Protocol. (Read-Only).
        /// </summary>
        abstract public string ProtocolName
        {
            get;
        }

        /// <summary>
        /// The connection parameters used to connect to the remote server.
        /// </summary>
        abstract public FLVStreamingParams ConnectionParameters
        {
            get;
            set;
        }

        /// <summary>
        /// Called when the server invokes a remote "method".
        /// </summary>
        abstract public fRemoteCallHandler RemoteCallHandler
        {
            get;
            set;
        }

        /// <summary>
        /// Calls a remote "actionscript" method on the server.
        /// </summary>
        /// <param name="methodName">The name of the method to call.</param>
        /// <param name="callbackFunc">The callback function to be called when this method returns.</param>
        /// <param name="methodParameters">A list of parameters to pass to the method.</param>
        abstract public void call(string methodName, fMethodCallback callbackFunc,
            params object[] methodParameters);

        /// <summary>
        /// Returns an appropriate protocol handler based on the protocol string.
        /// </summary>
        /// <param name="protocol">protocol string</param>
        /// <returns>A proper ConnectionProtocol that handles this protocol.</returns>
        public static ConnectionProtocol getProtocolHandler(string protocol)
        {
            if (protocol.ToLower() == "rtmp")
            {
                return new RTMPClient();
            }
            else if (protocol.ToLower()  == "rtmpt")
            {
                return new RTMPTClient();
            }
            else
            {
                return new RTMPClient();
            }
        }

        public abstract bool sendFLVTag(byte[] buffer, FLVTag tag);
    }
}
