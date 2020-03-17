using Hotel_Booking.Components.Enumeration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Booking.Components.Logger
{
    public class LoggerHandler
    {
        private string _ID = Security.Crypt.GenerateSHA256(DateTime.Now.ToString());
        public string ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                if (value != this._ID)
                {
                    this._ID = value;
                }
            }
        }

        private string _Message = "";
        public string Message
        {
            get
            {
                return this._Message;
            }
            set
            {
                if (value != this._Message)
                {
                    this._Message = value;
                }
            }
        }

        private DateTime _LogDate = DateTime.Now;
        public DateTime LogDate
        {
            get
            {
                return this._LogDate;
            }
            set
            {
                if (value != this._LogDate)
                {
                    this._LogDate = value;
                }
            }
        }

        private LogType _LogType = LogType.Success;
        public LogType LogType
        {
            get
            {
                return this._LogType;
            }
            set
            {
                if (value != this._LogType)
                {
                    this._LogType = value;
                }
            }
        }

        private string _CalledMethod = "";
        public string CalledMethod
        {
            get
            {
                return this._CalledMethod;
            }
            set
            {
                if (value != this._CalledMethod)
                {
                    this._CalledMethod = value;
                }
            }
        }


        public LoggerHandler()
        {
            
        }

        public LoggerHandler(string Message, LogType LogType, string CalledMethod)
        {
            this.Message = Message;
            this.LogType = LogType;
            this.CalledMethod = CalledMethod;
        }

        public void WriteLog()
        {
            FlushData();
        }

        public void WriteLog(string Message, LogType LogType, string CalledMethod)
        {
            this.Message = Message;
            this.LogType = LogType;
            this.CalledMethod = CalledMethod;
            FlushData();
        }

        private void FlushData()
        {
            // Initialize Object
            List<LoggerHandler> LoggerHandlers = new List<LoggerHandler>();
            LoggerHandler LoggerHandler = new LoggerHandler();
            string JsonText = "";

            using (StreamReader sr = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Context", "log.json")))
            {
                JsonText = sr.ReadToEnd();
                sr.Close();
            }

            // Deserialize Object
            LoggerHandlers = JsonConvert.DeserializeObject<List<LoggerHandler>>(JsonText);

            if(LoggerHandlers is null)
            {
                LoggerHandlers = new List<LoggerHandler>();
            }

            LoggerHandler.ID = this.ID;
            LoggerHandler.Message = this.Message;
            LoggerHandler.LogDate = this.LogDate;
            LoggerHandler.LogType = this.LogType;
            LoggerHandler.CalledMethod = this.CalledMethod;

            LoggerHandlers.Add(LoggerHandler);

            // Serialize to JsonText
            JsonText = JsonConvert.SerializeObject(LoggerHandlers, Formatting.Indented);

            using (StreamWriter sw =new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Context", "log.json")))
            {
                sw.Write(JsonText);
                sw.Close();
            }

        }
    }
}
