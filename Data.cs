using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiManeger
{ 
    class Messege
    {
    public int Id { get; set; }
    public string Name { get; set; }
    public  virtual string Type { get; set; }
     
    }

    class SMS : Messege
    {
        private string type;
        public override string Type
        {
            set { type = "SMS"; }
            get { return type; }
        }
    }

    class MMS : Messege
    {
        private string type;
        public override string Type
        {
            set { type = "MMS"; }
            get { return type; }
        }
    }

    class VideoMess : Messege
    {
        private string type;
        public override string Type
        {
            set { type = "VideoMess"; }
            get { return type; }
        }
    }



}
       
