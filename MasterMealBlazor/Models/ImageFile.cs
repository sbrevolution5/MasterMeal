using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMealBlazor.Models
{
    public class ImageFile
    {
        public int Id { get; set; }
        public byte[] ImageData { get; set; }
        public string ContentType { get; set; }
    }
}
