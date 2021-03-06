using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace csmvvm.entity {

    [DataContract]
    public class SampleEntity {

        [DataMember (Name = "id")]
        public int Id { get; set; }

        [DataMember (Name = "name")]
        public string Name { get; set; }
    }
}